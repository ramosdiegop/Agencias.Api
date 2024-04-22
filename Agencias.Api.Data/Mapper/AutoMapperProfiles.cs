using Agencias.Api.Data.Data;
using Agencias.Api.Domain.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Mapper
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Agencia, AgenciaDto>();//mapea desde Autor hacia AutorDTO y viceversa

		}

	}
}
