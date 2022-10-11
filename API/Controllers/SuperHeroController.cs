using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.Core.EntitiesDto;
using SuperHero.Infrastructure.Services;

namespace SuperHero.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly SuperHeroService _service;
        public SuperHeroController(SuperHeroService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroDto>>> GetSuperHeroes()
        {
            return Ok(await _service.GetSuperHeroes());
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHeroDto>>> CreateSuperHero(SuperHeroDto hero)
        {
            return Ok(await _service.CreateSuperHero(hero));
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeroDto>>> UpdateSuperHero(SuperHeroDto hero)
        {
            var dbHeroes = await _service.UpdateSuperHero(hero);
            if (dbHeroes == null)
                return BadRequest("Hero not found");

            return Ok(dbHeroes);
        }
    
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeroDto>>> DeleteSuperHero(int id)
        {
            var dbHeroes = await _service.DeleteSuperHero(id);
            if (dbHeroes == null)
                return BadRequest("Hero not found.");

            return Ok(dbHeroes);
        }
    }
}

