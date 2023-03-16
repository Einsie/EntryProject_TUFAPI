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
 * Last edit: 16.03.2023
 * Notes: 
 */

// Using statements necessary for function:
using Microsoft.AspNetCore.Mvc;
using EntryProject_TUFAPI.Models;
using EntryProject_TUFAPI.Data;
using System.Text.Json;

namespace EntryProject_TUFAPI.Controllers
{
    [Route("api/TUFAPI")]       //Definining the route the API shall use
    [ApiController]     //Define the type of this class
    public class TUFAPIController : ControllerBase //this class derives itself from the ControllerBase class
    {

        /* Method: GETTUF
         * Description: The primary GET request sent to the API that will initiate the necessary tasks of
         * gaining information from device and return this back to the user in converted string format with 200 OK response if everything
         * worked or with 404 not found if TUF no data was found from server
         * 
         * HTTPGet: define the type of the method as GET request and provide the possible response types produced
         * ProducesResponseType: document possible returned response codes
         * return: this method returns an action result code along with a Json serialized string variable consisting of the converted TUF data
         * 
         * Notes:
         */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JsonResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(JsonResult))]
        public JsonResult GetTUF()
        {
            TUF newTUF = new TUF();    // create a new TUF object which will upon creation initiate the process and gain all necessary TUF data
            if(newTUF.TUFRegisterList.Count == 0)  // check if RegisterList successfully added any elements into its list or if elements inside it remain 0
            {
                JsonResult failedToFindTUFData = new JsonResult("TUF Data not found");
                failedToFindTUFData.StatusCode = StatusCodes.Status404NotFound;
                return failedToFindTUFData; // return 404 not found code if no elements exist
            }
            else
            {
                TUFStore newTUFSTORE = new TUFStore(newTUF); // create a new TUFStore object handling all the conversion and storing the object with relevant data, provide created TUF object in parameter
                JsonResult TUFResult = new JsonResult(newTUFSTORE.TUFDataJson);
                TUFResult.StatusCode = StatusCodes.Status200OK;
                TUFResult.ContentType = "application/json";
                return TUFResult;
                //return new JsonResult(Ok(newTUFSTORE.TUFDataJson)); // return ok code along with the necessary list
            }
        }
    }
}
