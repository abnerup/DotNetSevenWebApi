

namespace DotNetSevenWebApi.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext context;
        public SuperHeroService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<SuperHero>> CreateHero(SuperHero hero)
        {
            context.SuperHeroes.Add(hero);
            await context.SaveChangesAsync();
            var heroes = await context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<List<SuperHero>> DeleteHero(int Id)
        {
            var hero = await context.SuperHeroes.FindAsync(Id);

            if (hero == null)
            {
                return null;
            }
            context.SuperHeroes.Remove(hero);
            await context.SaveChangesAsync();

            var heroes = await context.SuperHeroes.ToListAsync();

            return heroes;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero> GetHero(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);

            if (hero == null)
            {
                return null;
            }

            return hero;
        }

        public async Task<List<SuperHero>>? UpdateHero(int Id, SuperHero req)
        {
            var hero = await context.SuperHeroes.FindAsync(Id);

            if (hero == null)
            {
                return null;
            }
            hero.Name = req.Name;
            hero.LastName = req.LastName;
            hero.FirstName = req.FirstName;
            await context.SaveChangesAsync();

            var heroes = await context.SuperHeroes.ToListAsync();
            return heroes;
        }
    }
}
