using AutoMapper;
using SuperHero.Core.Entities;
using SuperHero.Core.EntitiesDto;

namespace SuperHero.Infrastructure.Mappers;

public class AutoMapperProfile : Profile
{

    public AutoMapperProfile()
    {
        CreateMap<SuperHeroModel, SuperHeroViewModel>();
        CreateMap<SuperHeroViewModel, SuperHeroModel>();
    }
}
