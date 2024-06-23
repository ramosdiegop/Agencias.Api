﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("usuario")]
	public class Usuario
	{
		[Key]
		public int Id { get; set; }
		[Column("usuario")]
		public string Nombre_Usuario { get; set; }
		public string Nombre { get; set; }
		public string? Password { get; set; }
		
	}
}
