var builder = WebApplication.CreateBuilder(args);
var MyAllowOrigins = "_myAllowOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
