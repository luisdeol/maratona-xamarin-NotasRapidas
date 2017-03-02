﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotasRapidasApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NotasRapidasApi.Controllers
{
    [Route("api/[controller]")]
    public class NotasController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Nota> Get()
        {
            return new[]
            {
                new Nota {Id = 1, Description = "Uma nota rapida", Title = "Primeira"},
                new Nota {Id = 1, Description = "Uma nota rapida", Title = "Segunda"}
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
