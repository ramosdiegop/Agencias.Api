using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Domain.Dtos
{
	public class UsuarioDto
	{
		public int Id { get; set; }
		public string? Nombre_Usuario { get; set; }
		public string? Nombre { get; set; }
		public string? Password { get; set; }

		public List<AgenteAgencia>? agenteAgencias { get; set; }

	}



}
