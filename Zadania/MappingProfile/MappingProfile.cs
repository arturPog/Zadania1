using Microsoft.Extensions.Logging;
using AutoMapper;
using Zadania.Models;

namespace Zadania.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<RootVM, Root>();
            CreateMap<ResultVM, Result>();
            CreateMap<SubjectVM, Subject>();
            CreateMap<RepresentativeVM, Representative>();
            CreateMap<EntityPersonWspolnikVM, EntityPersonWspolnik>();
            CreateMap<EntityPersonProkurentVM, EntityPersonProkurent>();
        }
    }
}
