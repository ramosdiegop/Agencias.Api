using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Domain.Dtos
{
	public class AgenteDto
	{
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public string? Cuit { get; set; }

		public List<AgenteAgencia>? agenteAgencias { get; set; }

	}

	public class AgenteAgencia
	{
		public int Id { get; set; }
		public int Idagencia { get; set; }
		public string Nombre { get; set; } = null!;
		public string? Direccion { get; set; }
		public string? Localidad { get; set; }
		public string? Titular { get; set; }
		public string? Cuit { get; set; }
		public int? Llave { get; set; }
		public string? Ok { get; set; }
		public string? Banco { get; set; }

	}

}
