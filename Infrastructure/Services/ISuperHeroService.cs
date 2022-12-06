using AutoMapper;
using SuperHero.Core.EntitiesDto;
using SuperHero.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Infrastructure.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHeroDto>?> GetSuperHeroes();
        Task<List<SuperHeroDto>?> CreateSuperHero(SuperHeroDto hero);
        Task<List<SuperHeroDto>?> UpdateSuperHero(SuperHeroDto hero);
        Task<List<SuperHeroDto>?> DeleteSuperHero(int HeroId);
    }
}
