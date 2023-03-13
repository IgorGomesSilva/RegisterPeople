using Microsoft.AspNetCore.Mvc;
using RegisterPeople.API.Controllers.Extensions;
using RegisterPeople.API.ViewModels.Response;
using RegisterPeople.Application.Dtos.Person;
using RegisterPeople.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RegisterPeople.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonApplicationService _personApplicationService;

        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }

        [HttpGet]
        [Route("get-all")]
        [SwaggerOperation(Summary = "Get all", Description = "Get All persons")]
        [SwaggerResponse(200, "Everything Worked")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _personApplicationService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Get by Id", Description = "Get one person by Id")]
        [SwaggerResponse(200, "Everything Worked")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _personApplicationService.GetById(id);
                if (result == null)
                {
                    return NotFound(false.AsNotFoundResponse("Pessoa não encontrada."));
                }
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adding", Description = "Adding person")]
        [SwaggerResponse(201, "Person Create")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> Add([FromBody] PersonDtoCreate person)
        {
            try
            {
                if (!person.Email.IsEmail())
                {
                    return UnprocessableEntity(false.AsUnprocessableResponse("Por favor entre com um e-mail válido."));
                }

                if (!person.CPF.ValidaCPF())
                {
                    return UnprocessableEntity(false.AsUnprocessableResponse("Por favor entre com um CPF válido."));
                }

                await _personApplicationService.Add(person);

                return Ok(true.AsSuccessResponse("Pessoa registrada com sucesso."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update", Description = "Update person")]
        [SwaggerResponse(204, "Person Update")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> Update([FromBody] PersonDtoUpdate person)
        {
            try
            {
                if (!person.Email.IsEmail())
                {
                    return UnprocessableEntity(false.AsUnprocessableResponse("Por favor entre com um e-mail válido."));
                }

                await _personApplicationService.Update(person);

                return Ok(true.AsSuccessResponse("Pessoa atualizada com sucesso."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Delete", Description = "Delete person")]
        [SwaggerResponse(200, "Person Delete")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _personApplicationService.Remove(id);

                return Ok(true.AsSuccessResponse("Pessoa deletada com sucesso."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
