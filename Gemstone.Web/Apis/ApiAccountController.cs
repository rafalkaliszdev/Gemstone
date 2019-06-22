using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using Gemstone.Web.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gemstone.Core.Interfaces.Repositories;

namespace Gemstone.Web.Apis
{
    [Route("api/account")]
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class ApiAccountController : AbstractController
    {
        private readonly IAsyncRepository<Account> repository;

        public ApiAccountController(IAsyncRepository<Account> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(Account[]))]
        public IActionResult Get()
        {
            IEnumerable<Account> accounts = repository.ListAllAsync().Result;
            return new JsonResult(accounts);
            //return Ok(accounts);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            Account Account = await repository.GetByIdAsync(id);
            if (Account == null)
                return NotFound("Account not found");

            return Ok(Account);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account model)
        {
            if (model == null)
                return BadRequest("Account is null");

            await repository.AddAsync(model);
            return CreatedAtRoute("Get", new { Id = model.ID }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Account model)
        {
            if (model == null)
                return BadRequest("Account is null");

            Account record = await repository.GetByIdAsync(id);
            if (record == null)
                return NotFound("Account not found");

            await repository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Account record = await repository.GetByIdAsync(id);
            if (record == null)
                return NotFound("Account not found");

            await repository.DeleteAsync(record);
            return NoContent();
        }
    }
}
