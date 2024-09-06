using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Context;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();

            return Ok(heroes);
        }

        [HttpGet("{heroName}")]
        public async Task<ActionResult<SuperHero>> GetHero(string heroName)
        {
            var hero = await _context.SuperHeroes.FindAsync(heroName);

            if (hero == null)
            {
                return NotFound("Hero not found.");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.FindAsync(hero));
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> DeleteHero(string heroName)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(heroName);
            if (dbHero == null)
            {
                return NotFound("Hero not found.");
            }

            _context.SuperHeroes.Remove(dbHero);

            await _context.SaveChangesAsync();
            return Ok(dbHero);

        }

    }

}
