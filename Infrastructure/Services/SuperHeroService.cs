using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperHero.Core.Entities;
using SuperHero.Core.EntitiesDto;
using SuperHero.Infrastructure.Data;

namespace SuperHero.Infrastructure.Services
{
    public class SuperHeroService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SuperHeroService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SuperHeroDto>> GetSuperHeroes()
        {
            return await _context.SuperHeroes.Select(hero => _mapper.Map<SuperHeroDto>(hero)).ToListAsync();
        }

        public async Task<List<SuperHeroDto>> CreateSuperHero(SuperHeroDto hero) 
        {
            _context.SuperHeroes.Add(_mapper.Map<SuperHeroModel>(hero));
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.Select(hero => _mapper.Map<SuperHeroDto>(hero)).ToListAsync();
        }

        public async Task<List<SuperHeroDto>> UpdateSuperHero(SuperHeroDto hero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);
            if (dbHero == null)
                return null;

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.Select(hero => _mapper.Map<SuperHeroDto>(hero)).ToListAsync();
        }

        public async Task<List<SuperHeroDto>> DeleteSuperHero(int HeroId)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(HeroId);
            if (dbHero == null)
                return null;

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.Select(hero => _mapper.Map<SuperHeroDto>(hero)).ToListAsync();
        }

    }
}
