using AutoMapper;
using Domain.Films.Entities;
using DTOs.Genero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Extra.Mapper
{
    public class GeneroProfile : Profile
    {
        public GeneroProfile()
        {
            CreateMap<Genero, GeneroGetAllDTO>().ReverseMap();
        }
    }
}
