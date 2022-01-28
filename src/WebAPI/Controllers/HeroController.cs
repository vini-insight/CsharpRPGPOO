using System;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.DTO;
using Src.Domain.Entities;
using Src.Database;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/heros")]
    public class HeroController : ControllerBase
    {
        private DataContext _context;

        public HeroController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> List()
        {
            var heros = await _context.Heros.ToListAsync();
            return heros;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Hero>> GetById(int id)
        {
            var hero = await _context.Heros.FirstOrDefaultAsync(h => h.Id == id);
            return hero;
        }

        [HttpPost]
        public async Task<ActionResult<Hero>> create([FromBody] CreateHero hero)
        {
            var newHero = new Hero(hero);

            _context.Heros.Add(newHero);
            await _context.SaveChangesAsync();

            return Ok(newHero);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Hero>> delete(int id, [FromBody] UpdateHero hero)
        {
            var result = await _context.Heros.SingleOrDefaultAsync(h => h.Id == id);

            if (result != null)
            {
                result.Name = hero.Name;
                result.RealName = hero.RealName;
                result.groupId = hero.groupId;
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await _context.Heros.SingleOrDefaultAsync(h => h.Id == id);

            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return Ok("hero deleted");
            }
            else
            {
                return BadRequest("hero not found");
            }
        }

        [HttpGet("groups/{id:int}")]
        public async Task<ActionResult<List<Group>>> Groups(int id)
        {
            var heros = await _context.Heros
            .Include(x => x.group)
            .Where(x => x.groupId == id)
            .ToListAsync();

            return Ok(heros);
        }

    }
}