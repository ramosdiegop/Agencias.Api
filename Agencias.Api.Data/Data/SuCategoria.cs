using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("subcategoria")]
	public class SubCategoria
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Categoria")]
		public int Idcategoria { get; set; }
		public int Antiguedad { get; set; }
		public Double Tope_Ventas { get; set; }
		public Double Por_ProdPro { get; set; }
		public Double Por_ProdSup { get; set; }
		public Double Por_ProdAge { get; set; }
		public Double Por_AdmiPro { get; set; }
		public Double Por_AdmiSup { get; set; }
		public Double Por_AdmiAge { get; set; }

		public virtual Categoria? Categoria { get; set; }

	}
}
