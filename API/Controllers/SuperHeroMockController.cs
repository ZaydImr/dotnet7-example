using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.Core.EntitiesDto;
using SuperHero.Infrastructure.Services;

namespace SuperHero.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroMockController : ControllerBase
    {
        private readonly ILogger<SuperHeroController> _logger;
        private static List<SuperHeroViewModel> heros = new List<SuperHeroViewModel> {
                new SuperHeroViewModel { Id = 1, FirstName = "Jeff", LastName = "Loveness", Name = "Ant-Man" },
                new SuperHeroViewModel { Id = 2, FirstName = "Bob", LastName = "Kane", Name = "Batman" },
                new SuperHeroViewModel { Id = 3, FirstName = "Tony", LastName = "Stark", Name = "Iron Man" }
            };
        public SuperHeroMockController(ILogger<SuperHeroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroViewModel>>> GetSuperHeroes()
        {
            try
            {
                _logger.LogInformation("GetHeroes");
                return Ok(heros);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHeroViewModel>>> CreateSuperHero(SuperHeroViewModel hero)
        {
            try
            {
                _logger.LogInformation("Add SuperHero");
                heros.Add(hero);
                return Ok(heros);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeroViewModel>>> UpdateSuperHero(SuperHeroViewModel hero)
        {
            try
            {
                _logger.LogInformation("Update SuperHero");
                var dbHeroes = heros.Where(hero => hero.Id == hero.Id).FirstOrDefault();
                if (dbHeroes == null)
                    return NotFound("Hero not found");

                heros.RemoveAt(heros.IndexOf(dbHeroes));
                heros.Add(hero);
                return Ok(heros);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeroViewModel>>> DeleteSuperHero(int id)
        {
            try
            {
                _logger.LogInformation("Delete SuperHero");
                var dbHeroes = heros.Where(hero => hero.Id == id).FirstOrDefault();
                if (dbHeroes == null)
                    return NotFound("Hero not found.");

                heros.RemoveAt(heros.IndexOf(dbHeroes));
                return Ok(heros);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}

