﻿using System;
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
        public async Task<IActionResult> Get()
        {
            IEnumerable<Account> accounts = await repository.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            Account Account = await repository.GetByIdAsync(id);
            if (Account == null)
                return NotFound("The Account record couldn't be found.");

            return Ok(Account);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account model)
        {
            if (model == null)
                return BadRequest("Account is null.");

            await repository.AddAsync(model);
            return CreatedAtRoute("Get", new { Id = model.ID }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Account model)
        {
            if (model == null)
                return BadRequest("Account is null.");

            Account record = await repository.GetByIdAsync(id);
            if (record == null)
                return NotFound("The Account record couldn't be found.");

            await repository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Account record = await repository.GetByIdAsync(id);
            if (record == null)
                return NotFound("The Account record couldn't be found.");

            await repository.DeleteAsync(record);
            return NoContent();
        }
    }
}
