using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("agente")]
	public class Agente
	{
		/*  public Agente()
          {
              Agencia = new HashSet<Agencium>();
          }*/
		[Key]
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public string? Cuit { get; set; }

		public virtual ICollection<Agencia>? Agencias { get; set; }
	}
}
