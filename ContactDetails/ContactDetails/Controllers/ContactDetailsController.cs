using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactDetails.Service.DAL.Model;
using ContactDetails.Domain.Queries.Data;
using ContactDetails.Domain.Commands.Data;
using MediatR;

namespace ContactDetails.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    public class ContactDetailsController : Controller
    {
        private readonly IMediator _mediator;

        public ContactDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetPersonsAll")]
        [ProducesResponseType(typeof(IEnumerable<Person>), 200)]
        //[ProducesResponseType(404)]
        public Task<IEnumerable<Person>> GetPersonsAll() => _mediator.Send(new GetPersonsAllQuery());

        public Task<int> GetPersonsCount() => _mediator.Send(new GetPersonsNumberQuery());

        // POST api/values
        [HttpPost("AddPerson")]
        [ProducesResponseType(typeof(Person), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            try
            {
                await _mediator.Send(new AddPersonCommand(person));
                return new ObjectResult(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values
        [HttpPut("EditPerson")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EditPerson([FromBody] Person person)
        {
            await _mediator.Send(new EditPersonCommand(person));
            return new ObjectResult(person);
        }

        [HttpDelete("DeletePerson")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeletePerson([FromBody] Person person)
        {
            bool sucess = await _mediator.Send(new DeletePersonCommand(person.Id));
            return new ObjectResult(sucess);
        }

        // POST api/values
        [HttpPost("AddAddress")]
        [ProducesResponseType(typeof(Person), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAddress([FromBody] Address address)
        {
            if (address == null)
            {
                return BadRequest();
            }

            try
            {
                await _mediator.Send(new AddAddressCommand(address));
                return new ObjectResult(address);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values
        [HttpPut("EditAddress")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EditAddress([FromBody] Address address)
        {
            await _mediator.Send(new EditAddressCommand(address));
            return new ObjectResult(address);
        }

        [HttpDelete("DeleteAddress")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAddress([FromBody] Address address)
        {
            bool success = await _mediator.Send(new DeleteAddressCommand(address.Id));
            return new ObjectResult(success);
        }
    }
}
