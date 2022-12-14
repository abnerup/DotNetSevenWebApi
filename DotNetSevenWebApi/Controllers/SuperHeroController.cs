using DotNetSevenWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetSevenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService superHeroService;
      

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this.superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(await superHeroService.GetAllHeroes());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
        {
            var hero = await superHeroService.GetHero(id);

            if (hero == null)
            {
                return NotFound("Hero Not foud");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateHero(SuperHero hero)
        {
            var result = await superHeroService.CreateHero(hero);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int Id , SuperHero req)
        {
            var hero = await superHeroService.UpdateHero(Id, req);

            if (hero == null)
            {
                return NotFound("Hero Not foud");
            }
            return Ok(hero);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int Id)
        {
            var result = await superHeroService.DeleteHero(Id);
            if (result == null)
            {
                return NotFound("Hero not found");
            }
            return Ok(result);
        }

    }
}
