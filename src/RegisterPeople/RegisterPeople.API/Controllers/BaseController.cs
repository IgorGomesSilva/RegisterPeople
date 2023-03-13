using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterPeople.API.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeople.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController() { }

        public override OkObjectResult Ok(object result)
        {
            if (!(result is BaseResponse))
            {
                return base.Ok(result.AsSuccessResponse());
            }
            return base.Ok(result);
        }

        public override UnprocessableEntityObjectResult UnprocessableEntity(object error)
        {
            if (!(error is BaseResponse))
            {
                return base.UnprocessableEntity(error.AsUnprocessableResponse());
            }
            return base.UnprocessableEntity(error);
        }
    }
}
