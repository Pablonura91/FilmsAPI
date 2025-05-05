using AutoMapper;
using Domain.Films.Entities;
using DTOs.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Extra.Mapper
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorGetAllDTO>().ReverseMap();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<Actor, ActorCreateDTO>().ReverseMap();
            CreateMap<Actor, ActorUpdateDTO>().ReverseMap();
        }
    }
}
