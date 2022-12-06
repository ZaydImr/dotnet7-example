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
        private readonly ILogger<SuperHeroController> _logger;
        private readonly ISuperHeroService _service;
        public SuperHeroController(ILogger<SuperHeroController> logger, ISuperHeroService service) 
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroDto>>> GetSuperHeroes()
        {
            try
            {
                _logger.LogInformation("GetHeroes");
                return Ok(await _service.GetSuperHeroes());
            }catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHeroDto>>> CreateSuperHero(SuperHeroDto hero)
        {
            try
            {
                _logger.LogInformation("Add SuperHero");
                return Ok(await _service.CreateSuperHero(hero));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeroDto>>> UpdateSuperHero(SuperHeroDto hero)
        {
            try
            {
                _logger.LogInformation("Update SuperHero");
                var dbHeroes = await _service.UpdateSuperHero(hero);
                if (dbHeroes == null)
                    return NotFound("Hero not found");

                return Ok(dbHeroes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }
            
        }
    
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeroDto>>> DeleteSuperHero(int id)
        {
            try
            {
                _logger.LogInformation("Delete SuperHero");
                var dbHeroes = await _service.DeleteSuperHero(id);
                if (dbHeroes == null)
                    return NotFound("Hero not found.");

                return Ok(dbHeroes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}

