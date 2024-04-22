﻿using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Mapper
{
	public class MappingProfile : IMapping
	{

		public Agencia MappAgencia(AgenciaDto amap)
		{
			var age = new Agencia
			{
				Id = amap.Id,
				Idagencia = amap.Idagencia,
				Nombre = amap.Nombre,
				Direccion = amap.Direccion,
				Idlocalidad = amap.Idlocalidad,
				Titular = amap.Titular,
				Cuit = amap.Cuit,
				Llave = amap.Llave,
				Ok = amap.Ok,
				Banco = amap.Banco,
				Idagente = amap.Idagente
			};

			return age;
		}
	}
}
