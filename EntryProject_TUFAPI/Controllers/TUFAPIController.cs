/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: This class receives and controls the handling of request and their return to user
 * Created: 13.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 15.03.2023
 * Notes: 
 */

// Using statements necessary for function:
using Microsoft.AspNetCore.Mvc;
using EntryProject_TUFAPI.Models;

// Following using statements are in development:
//using EntryProject_TUFAPI.Models.DTO;
using EntryProject_TUFAPI.Data;

namespace EntryProject_TUFAPI.Controllers
{
    [Route("api/TUFAPI")]       //Definining the route the API shall use
    [ApiController]     //Define the type of this class
    public class TUFAPIController : ControllerBase //this class derives itself from the ControllerBase class
    {

        /* Method: GETTUF
         * Description: The primary GET request sent to the API that will initiate the necessary tasks of
         * gaining information from device and return this back to the user with 200 OK response if everything
         * worked or with 404 not found if TUF no data was found from server
         * 
         * HTTPGet: define the type of the method as GET request and provide the possible response types produced
         * ProducesResponseType: document possible returned response codes
         * return: this method returns an action result code along with an IEnumerable list consisting of the TUF's Register values
         * 
         * Notes:
         */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetTUF()
        {
            TUF newTUF = new TUF();    // create a new TUF object which will upon creation initiate the process and gain all necessary TUF data
            if(newTUF.TUFRegisterList.Count == 0)  // check if RegisterList successfully added any elements into its list or if elements inside it remain 0
            {
                return NotFound(); // return 404 not found code if no elements exist
            }
            else
            {
                TUFStore newTUFSTORE = new TUFStore(newTUF);
                return Ok(newTUFSTORE.TUFListJson); // return ok code along with the nessary list
            }
        }
    }
}
