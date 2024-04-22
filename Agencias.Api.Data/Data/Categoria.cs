using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("categoria")]
	public class Categoria
	{
		[Key]
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public int? ProduOSuper { get; set; }
		public int? Cantidad_Campana { get; set; }
		public int? Proxima { get; set; }
		public int? Tope_por { get; set; }


		public virtual List<SubCategoria>? SubCategorias { get; set; }

	}
}
