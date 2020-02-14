﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCoreMVC.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleApiController : ControllerBase
    {
        // GET: api/ExampleApi
        [HttpGet]
        public IActionResult Get()
        {
            var rnd = new Random((new Random((int)DateTime.Now.Ticks).Next(int.MinValue, int.MaxValue)));

            var count = rnd.Next(1, 100000);
            var sumC = 0;
            for (int i = 0; i < count; i++)
            {
                sumC += rnd.Next();
            }

            var retO = new { count = count, sum = sumC };

            return Ok(retO);
        }

        // GET: api/ExampleApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ExampleApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ExampleApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
