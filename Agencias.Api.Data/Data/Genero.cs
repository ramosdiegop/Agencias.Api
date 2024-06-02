﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("genero")]
	public class Genero
	{
		[Key]
		public int Id { get; set; }
		public string? Detalle { get; set; }

	}
}
