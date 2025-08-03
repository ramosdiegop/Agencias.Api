using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("agencia")]
	public class Agencia
	{
		[Key]
		public int Id { get; set; }
		public int Idagencia { get; set; }
		public string Nombre { get; set; } = null!;
		public string? Direccion { get; set; }
		[ForeignKey("Localidad")]
		public int Idlocalidad { get; set; }
		public string? Titular { get; set; }
		public string? Cuit { get; set; }
		public int? Llave { get; set; }
		public string? Ok { get; set; }
		public string? Banco { get; set; }
		[ForeignKey("Agente")]
		public int Idagente { get; set; }
		public DateTime Created_Date { get; set; }
		public int Created_User { get; set; }
		public DateTime? Modified_Date { get; set; }
		public int? Modified_User { get; set; }


		public virtual Agente? Agente { get; set; }
		public virtual Localidad? Localidad { get; set; }
	}
}
