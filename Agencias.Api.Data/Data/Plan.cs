using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("plan")]
	public class Plan
	{
		[Key]
		public int Id { get; set; }
		public int Codigo { get; set; }
		public string? Detalle { get; set; }
		public double Relacion_DI { get; set; }
		public double Relacion_Cta { get; set; }
		public double Relacion_Anti_Di { get; set; }
		public double Relacion_Gto_Prod { get; set; }
		public double Relacion_Gto_Admi { get; set; }
		public double Relacion_Adelanto { get; set; } 
		public DateTime? Vigencia { get; set; }

	}
}
