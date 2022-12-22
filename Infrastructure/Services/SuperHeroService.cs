using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperHero.Core.Entities;
using SuperHero.Core.EntitiesDto;
using SuperHero.Infrastructure.Data;

namespace SuperHero.Infrastructure.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SuperHeroService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SuperHeroViewModel>?> GetSuperHeroes()
        {
            return await _context.SuperHeroes.Select(hero => _mapper.Map<SuperHeroViewModel>(hero)).ToListAsync();
        }

        public async Task<List<SuperHeroViewModel>?> CreateSuperHero(SuperHeroViewModel hero) 
        {
            _context.SuperHeroes.Add(_mapper.Map<SuperHeroModel>(hero));
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.Select(hero => _mapper.Map<SuperHeroViewModel>(hero)).ToListAsync();
        }

        public async Task<List<SuperHeroViewModel>?> UpdateSuperHero(SuperHeroViewModel hero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);
            if (dbHero == null)
                return null;

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.Select(hero => _mapper.Map<SuperHeroViewModel>(hero)).ToListAsync();
        }

        public async Task<List<SuperHeroViewModel>?> DeleteSuperHero(int HeroId)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(HeroId);
            if (dbHero == null)
                return null;

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.Select(hero => _mapper.Map<SuperHeroViewModel>(hero)).ToListAsync();
        }

    }
}
