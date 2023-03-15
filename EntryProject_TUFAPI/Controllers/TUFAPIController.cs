using Microsoft.AspNetCore.Mvc;
using EntryProject_TUFAPI.Models;
//using EntryProject_TUFAPI.Models.DTO;
//using EntryProject_TUFAPI.Data;

namespace EntryProject_TUFAPI.Controllers
{
    [Route("api/TUFAPI")]
    [ApiController]
    public class TUFAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TUF.registerDataStruct> GetTUF()
        {
            TUF newTUF = new TUF();
            return newTUF.TUFRegisterList;
            //return TUFStore._TUFList;
        }
    }
}
