using learning_webAPI.WebAPIClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learning_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroValuesController : ControllerBase
    {
       
        private readonly DataContext _context;

        public SuperHeroValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<superhero>>> Get() {
            
            
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        
        [HttpGet("{id}")]

        public async Task<ActionResult<superhero>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("hero not found");
            return Ok(hero);
        }

        [HttpPost]

        public async Task<ActionResult<List<superhero>>> AddHero(superhero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<superhero>>> UpdateHero(superhero request)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(request.id);
            if (dbHero == null)
                return BadRequest("hero not found");

            dbHero.name = request.name;
            dbHero.Firstname = request.Firstname;
            dbHero.Lastname = request.Lastname;
            dbHero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete]

        public async Task<ActionResult<List<superhero>>> Delete(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return BadRequest("hero not found");
            
            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());

        }
    }
}
