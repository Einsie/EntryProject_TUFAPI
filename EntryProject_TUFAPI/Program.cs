/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: Program class, created by Visual Studio 2022 as part of the initial project
 * template, begins the creation of the program being ran. Creates a builder for creating the
 * services and its option functions. Then the app is created from the builder to begin running the
 * relevant and necessary functions
 * of the app.
 * Created: 13.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 19.03.2023
 * Notes: This version of Authentication and authorization built with the help of tutorial by CodeWithJulian
 * at https://www.youtube.com/watch?v=f2IdQqpjR0c
 */

// State the libraries necessary for the functions being done in this class
using EntryProject_TUFAPI.Models;
using EntryProject_TUFAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



var builder = WebApplication.CreateBuilder(args); // create webapplication builder for creating the applications and its services 
var MyAllowOrigins = "_myAllowOrigins"; // This is the variable holding the name for the Cors policy being used

// Add services to the container.

// create cors service with defined policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowOrigins,
        policy =>
        {
            // policy is to allow any origin being used to do the API Http requests as well as them having any headers.
            // Headers may include jwt bearer tokens so this was included
            policy.AllowAnyOrigin()
                    .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IUserService, UserService>(); // creating a service with single instance of the IUserService type holding UserService class

// Adding to the Swaggergen services the option with security scheme we will be using. Bearer is an entity
// that holds the security key found in header parameters sent as part of the request. The name of the header
// is Authorization, which has to hold a string of the bearer and the key created upon login request. Only the string
// the authorization header of reference ID Bearer is considered in security schemes
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});


// create authentication service with the Jwtbearer defining what validations are being done on to
// JwtBearer's key string on Http get request as well as defining what are valid values for Issuer as well as
// what the issuer signing key is being used, a symmetricsecuity encoded from the key string in appsettings.json
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();


app.UseSwagger();

// Configure the HTTP request pipeline.

// SwaggerUI is being used for doing the login process and the client receiving the data, can also hold the Jwtbearer key for doing get request inside UI
app.UseSwaggerUI(); 

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowOrigins); // begins the use of the created Cors service with the policy option we've determined

app.UseAuthentication(); // added use of the created authentication
app.UseAuthorization();


app.MapControllers();

// This gives a post request to be used, in this case a database isn't being used, but this allows us to use
// UserLogin and IUserService in this way, created above as a singleton services, the main functionality is handled by
// Swagger to insert the login data and after login request has been given it calls the login function found below giving it the data.
app.MapPost("/login",
    (UserLogin user, IUserService service) => Login(user, service));


/*
 * Method: Login(UserLogin user, IUserService service)
 * Description: Login method is used for handling the login process, if a valid user is found with given userlogin data,
 * a new token will be created with:
 * a claim array holding all users relevant data we want stored in key, the issuer and audience declared in appsettings
 * for Jwt, an expiration duration as well as signing credentials created with symmetricsecurity key from key string in 
 * appsettings.json and a security algorithm of Sha384 the random string was created to match.
 * 
 * This token is then created into a string and returned back with an IResult including the statuscode
 * 
 * 
 * Parameter: user of type UserLogin, holds the user data received during login request
 * Parameter: service of type IUserService, a singleton service created in program.cs for confirming the userlogin data sent matches that of a user in
 * UserStore class and returning the found valid user or default value of null.
 * Return: IResult containing statuscode of successful or failed login as well as the signing key for the user to use for HtttpGet request authorization
 * 
 * Notes:
 */
IResult Login(UserLogin user, IUserService service)
{
    if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
    {
        var loggedInUser = service.Get(user);
        if (loggedInUser == null) return Results.NotFound("User not found");  // the default user value returned by service is null if it didn't match any users in UserStore

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
            new Claim(ClaimTypes.Email, loggedInUser.Email),
            new Claim(ClaimTypes.GivenName, loggedInUser.Givenname),
            new Claim(ClaimTypes.Surname, loggedInUser.Surname),
            new Claim(ClaimTypes.Role, loggedInUser.Role)
        };

        var token = new JwtSecurityToken
        (
            issuer: builder.Configuration["Jwt:Issuer"],
            audience: builder.Configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            SecurityAlgorithms.HmacSha384)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Results.Ok(tokenString);
    }
    else return Results.NotFound();
}

app.Run();
