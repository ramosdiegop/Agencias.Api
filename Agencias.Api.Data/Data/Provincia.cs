using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("provincia")]
	public class Provincia
	{
		[Key]
		public int Id { get; set; }
//		[Column("provincia")]
		public string CodigoProvincia { get; set; } = null!;
		public string Detalle { get; set; } = null!;

		public virtual ICollection<Localidad>? Localidades { get; set; }
	}

}
