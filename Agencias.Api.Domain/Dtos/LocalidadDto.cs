﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Domain.Dtos
{
	public class LocalidadDto
	{
		public int Id { get; set; }
		public int? CodigoPostal { get; set; }
		public string? Detalle { get; set; }
		public int? Idprovincia { get; set; }
		public string? Provincia { get; set; }
	}
}
