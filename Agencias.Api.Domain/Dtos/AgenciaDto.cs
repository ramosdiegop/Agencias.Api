using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Domain.Dtos
{
	public class AgenciaDto
	{
		public int Id { get; set; }
		public int Idagencia { get; set; }
		public string Nombre { get; set; } = null!;
		public string? Direccion { get; set; }
		public int Idlocalidad { get; set; }
		public string? Titular { get; set; }
		public string? Cuit { get; set; }
		public int? Llave { get; set; }
		public string? Ok { get; set; }
		public string? Banco { get; set; }
		public int Idagente { get; set; }
		public DateTime Created_Date { get; set; }
		public int Created_User { get; set; }
		public DateTime? Modified_Date { get; set; }
		public int? Modified_User { get; set; }


		public string? Localidad { get; set; }
		public string? Agente { get; set; }



	}
}
