using AutoMapper;
using Proyecto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Libros.Profiles
{
    public class LibroProfile : Profile
    {
        public LibroProfile()
        {
            CreateMap<Libro, LibroDTO>();
            CreateMap<Libro, LibroSmallDTO>();
            CreateMap<LibroBodyDTO, Libro>();
        }
    }
}
