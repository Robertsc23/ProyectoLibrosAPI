using AutoMapper;
using Proyecto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Editoriales.Profiles
{
    class EditorialProfile : Profile
    {
        public EditorialProfile()
        {
            CreateMap<Editorial, EditorialDTO>();
            CreateMap<EditorialBodyDTO, Editorial>();
        }
    }
}
