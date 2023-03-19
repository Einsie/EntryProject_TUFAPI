/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: TUFAPIController class receives and controls the handling of request and their return to user
 * Created: 13.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 19.03.2023
 * Notes: The initial core of this APIController and relevant structure classes built with the help of tutorial by
 * DotNetMastery at https://www.youtube.com/watch?v=_uZYOgzYheU
 */

// Using statements necessary for function:
using Microsoft.AspNetCore.Mvc;
using EntryProject_TUFAPI.Models;
using EntryProject_TUFAPI.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EntryProject_TUFAPI.Controllers
{
    // EnableCors attribute, can also be attached to specific method instead of the whole class.
    // EnableCors is used to enable Cors support using the policy name in the string, this has been set in Program.cs
    [EnableCors("_myAllowOrigins")] 
    [Route("/api")]       //Definining the route the API shall use
    [ApiController]     //Define the type of this class
    public class TUFAPIController : ControllerBase //this class derives itself from the ControllerBase class
    {

        /* Method: GETTUF()
         * Description: The primary GET request sent to the API that will initiate the necessary tasks of
         * gaining information from device and return this back to the user in converted string format with 200 OK response if everything
         * worked or with 404 not found if TUF no data was found from server
         * 
         * HttpGet: define the type of the method as GET request and provide the possible response types produced
         * Authorize: Attribute that declares this method requires successful authorization key for it to return desired data.
         * Authentication scheme used by Authorize is using JwtBearer to hold the key received in header of the HttpGet request,
         * and for authorization to pass the received key has to follow rules stated in Program.cs of validity as well as hold the role of
         * an Administrator.
         * ProducesResponseType: document possible returned response codes
         * return: this method returns an action result code along with a Json serialized string variable consisting of the converted TUF data
         * 
         * Notes:
         */
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JsonResult))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(JsonResult))]
        public JsonResult GetTUF()
        {
            TUF newTUF = new TUF();    // create a new TUF object which will upon creation initiate the process and gain all necessary TUF data
            if(newTUF.TUFRegisterList.Count == 0)  // check if RegisterList successfully added any elements into its list or if elements inside it remain 0
            {
                JsonResult failedToFindTUFData = new JsonResult("TUF Data not found"); // create a jsonresult with information on reason for failure
                failedToFindTUFData.StatusCode = StatusCodes.Status404NotFound; // set status code to 404 not found
                return failedToFindTUFData; // return 404 not found code if no elements exist
            }
            else
            {
                TUFStore newTUFSTORE = new TUFStore(newTUF); // create a new TUFStore object handling all the conversion and storing the object with relevant data, provide created TUF object in parameter
                JsonResult TUFResult = new JsonResult(newTUFSTORE.TUFDataJson); // create Jsonresult with the TUF data as its value
                TUFResult.StatusCode = StatusCodes.Status200OK; // set statuscode for result as 200 OK
                TUFResult.ContentType = "application/json"; // determine content to be json which will provide a .json file
                return TUFResult;
                //return new JsonResult(Ok(newTUFSTORE.TUFDataJson)); // return ok code along with the necessary list
            }
        }
    }
}
