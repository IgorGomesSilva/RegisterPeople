using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterPeople.API.ViewModels.Response;
using RegisterPeople.Application.Dtos.Address;
using RegisterPeople.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RegisterPeople.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private IAddressApplicationService _addressApplicationService;

        public AddressController(IAddressApplicationService addressApplicationService)
        {
            _addressApplicationService = addressApplicationService;
        }

        [HttpGet]
        [Route("get-all")]
        [SwaggerOperation(Summary = "Get all", Description = "Get All addresss")]
        [SwaggerResponse(200, "Everything Worked")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _addressApplicationService.GetAllAsync());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Get by Id", Description = "Get one address by Id")]
        [SwaggerResponse(200, "Everything Worked")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _addressApplicationService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(false.AsNotFoundResponse("Endereço não encontrado."));
                }
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("person/{IdPerson}")]
        [SwaggerOperation(Summary = "Get by IdPerson", Description = "Get many address by IdPerson")]
        [SwaggerResponse(200, "Everything Worked")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> GetByIdPersonAsync(int IdPerson)
        {
            try
            {
                var result = await _addressApplicationService.GetByIdPersonAsync(IdPerson);
                if (result == null)
                {
                    return NotFound(false.AsNotFoundResponse("Endereço não encontrado para essa Pessoa."));
                }
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adding", Description = "Adding address")]
        [SwaggerResponse(201, "address Create")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> Add([FromBody] AddressDtoCreate address)
        {
            try
            {
                await _addressApplicationService.AddAsync(address);

                return Ok(true.AsSuccessResponse("Endereço registrado com sucesso."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update", Description = "Update address")]
        [SwaggerResponse(204, "address Update")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> Update([FromBody] AddressDtoUpdate address)
        {
            try
            {

                await _addressApplicationService.UpdateAsync(address);

                return Ok(true.AsSuccessResponse("Endereço atualizado com sucesso."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Remove", Description = "Remove address")]
        [SwaggerResponse(200, "Address Remove")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            try
            {
                await _addressApplicationService.RemoveAsync(id);

                return Ok(true.AsSuccessResponse("Endereço deletado com sucesso."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
