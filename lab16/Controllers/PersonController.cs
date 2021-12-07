﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab16.Models;
using Microsoft.EntityFrameworkCore;


namespace lab16.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _context.Person.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var item = await _context.Person.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }



    }
}

