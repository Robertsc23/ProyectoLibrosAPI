using AutoMapper;
using Proyecto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Solicitantes.Profiles
{
    public class SolicitanteProfile : Profile
    {
        public SolicitanteProfile()
        {
            CreateMap<Solicitante, SolicitanteDTO>();
            CreateMap<Solicitante, SolicitanteSmallDTO>();
            CreateMap<SolicitanteBodyDTO, Solicitante>();
        }
    }
}
