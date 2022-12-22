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
        Task<List<SuperHeroViewModel>?> GetSuperHeroes();
        Task<List<SuperHeroViewModel>?> CreateSuperHero(SuperHeroViewModel hero);
        Task<List<SuperHeroViewModel>?> UpdateSuperHero(SuperHeroViewModel hero);
        Task<List<SuperHeroViewModel>?> DeleteSuperHero(int HeroId);
    }
}
