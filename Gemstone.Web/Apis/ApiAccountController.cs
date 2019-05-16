using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Gemstone.Web.Apis
{
    [Route("api/account")]
    [ApiController]
    public class ApiAccountController : Controller
    {
        private readonly IRepository<Account> repository;

        public ApiAccountController(IRepository<Account> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Account> accounts = repository.GetAll();
            return Ok(accounts);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Account Account = repository.Get(id);
            if (Account == null)
                return NotFound("The Account record couldn't be found.");

            return Ok(Account);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Account model)
        {
            if (model == null)
                return BadRequest("Account is null.");

            repository.Add(model);
            //return Created(new Uri($"https://localhost:44384/api/Account/{Account.Id}"), Account);
            return CreatedAtRoute("Get", new { Id = model.ID }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Account model)
        {
            if (model == null)
                return BadRequest("Account is null.");

            Account record = repository.Get(id);
            if (record == null)
                return NotFound("The Account record couldn't be found.");

            repository.Update(record, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Account record = repository.Get(id);
            if (record == null)
                return NotFound("The Account record couldn't be found.");

            repository.Delete(record);
            return NoContent();
        }
    }
}
