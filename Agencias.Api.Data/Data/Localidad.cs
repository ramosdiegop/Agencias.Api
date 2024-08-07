﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("localidad")]
	public class Localidad
	{

		[Key]
		public int Id { get; set; }
		public int CodigoPostal { get; set; }
		public string? Detalle { get; set; }
		[ForeignKey("Provincia")]
		public int? Idprovincia { get; set; }

		public virtual Provincia? Provincia { get; set; }
		public virtual ICollection<Agencia>? Agencias { get; set; }
	}
}
