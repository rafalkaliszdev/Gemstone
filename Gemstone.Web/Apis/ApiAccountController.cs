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
            IEnumerable<Account> accounts =  repository.ReadAllAsync().Result;
            return Ok(accounts);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            Account Account = await repository.ReadByIdAsync(id);
            if (Account == null)
                return NotFound("Record not found");

            return Ok(Account);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account model)
        {
            if (model == null)
                return BadRequest("Record is null");

            await repository.CreateAsync(model);
            return CreatedAtRoute("Get", new { Id = model.ID }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Account model)
        {
            if (model == null)
                return BadRequest("Record is null");

            Account record = await repository.ReadByIdAsync(id);
            if (record == null)
                return NotFound("Record not found");

            await repository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Account record = await repository.ReadByIdAsync(id);
            if (record == null)
                return NotFound("Record not found");

            await repository.DeleteAsync(record);
            return NoContent();
        }
    }
}
