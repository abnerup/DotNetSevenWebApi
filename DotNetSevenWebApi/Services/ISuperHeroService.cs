
namespace DotNetSevenWebApi.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero> GetHero(int id);
        Task<List<SuperHero>> CreateHero(SuperHero hero);
        Task<List<SuperHero>> UpdateHero(int Id, SuperHero req);
        Task<List<SuperHero>> DeleteHero(int Id);
    }
}
