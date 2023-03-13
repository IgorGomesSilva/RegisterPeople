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
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _personApplicationService.GetAllAsync());
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
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _personApplicationService.GetByIdAsync(id);
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
        public async Task<ActionResult> AddAsync([FromBody] PersonDtoCreate person)
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

                await _personApplicationService.AddAsync(person);

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
        public async Task<ActionResult> UpdateAsync([FromBody] PersonDtoUpdate person)
        {
            try
            {
                if (!person.Email.IsEmail())
                {
                    return UnprocessableEntity(false.AsUnprocessableResponse("Por favor entre com um e-mail válido."));
                }

                await _personApplicationService.UpdateAsync(person);

                return Ok(true.AsSuccessResponse("Pessoa atualizada com sucesso."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Remove", Description = "Remove person")]
        [SwaggerResponse(200, "Person Remove")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            try
            {
                await _personApplicationService.RemoveAsync(id);

                return Ok(true.AsSuccessResponse("Pessoa deletada com sucesso."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
