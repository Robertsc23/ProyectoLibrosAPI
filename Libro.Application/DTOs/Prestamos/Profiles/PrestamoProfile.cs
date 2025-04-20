using AutoMapper;
using Proyecto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Prestamos.Profiles
{
    class PrestamoProfile: Profile
    {     
            public PrestamoProfile()
            {
                CreateMap<Prestamo, PrestamoDTO>()
                    .ForMember(dest => dest.NombreSolicitante, opt => opt.MapFrom(src => src.Solicitante!.NombreCompleto));

                CreateMap<Prestamo, PrestamoSmallDTO>()
                    .ForMember(dest => dest.NombreSolicitante, opt => opt.MapFrom(src => src.Solicitante!.NombreCompleto));

                CreateMap<PrestamoBodyDTO, Prestamo>();
            }
        
    }
}
