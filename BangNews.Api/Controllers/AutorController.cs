﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BangNews.Api.Models;
using BangNews.Api.Data;

namespace BangNews.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly BangNewsApiContext _context;

        public AutorController(BangNewsApiContext context)
        {
            _context = context;
        }

        // GET: api/Autor
        [HttpGet]
        public IEnumerable<Autor> GetAutor()
        {
            return _context.Autor;
        }

        // GET: api/Autor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autor = await _context.Autor.FindAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        // PUT: api/Autor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor([FromRoute] int id, [FromBody] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autor.AutorID)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Autor
        [HttpPost]
        public async Task<IActionResult> PostAutor([FromBody] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Autor.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.AutorID }, autor);
        }

        // DELETE: api/Autor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autor = await _context.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();

            return Ok(autor);
        }

        private bool AutorExists(int id)
        {
            return _context.Autor.Any(e => e.AutorID == id);
        }
    }
}