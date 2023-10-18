using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OKEA.Library.Models.Response;
using System;

namespace OKEA.Service.Main.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandleBaseController : ControllerBase
    {
        protected IActionResult InternalServerError(Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObject
            {
                ErrorCode = -1,
                Message = ex.ToString()
            });
        }
        protected ResponseObject ErrorMessage(object data, string message, int errorCode = -1)
        {
            return new ResponseObject { Message = message, ErrorCode = errorCode, Data = data };
        }
        protected ResponseObject ErrorMessage(string message, int errorCode = -1)
        {
            return new ResponseObject { Message = message, ErrorCode = errorCode };
        }
        protected ResponseObject SuccessData(object data)
        {
            return new ResponseObject { ErrorCode = 0, Data = data };
        }
        protected ResponseObject SuccessData(object data, string message)
        {
            return new ResponseObject { ErrorCode = 0, Data = data, Message = message };
        }
        protected ResponseObject SuccessData()
        {
            return new ResponseObject { ErrorCode = 0 };
        }
        protected ResponseObject SuccessMessage(string message)
        {
            return new ResponseObject { ErrorCode = 0, Message = message };
        }
    }
}
