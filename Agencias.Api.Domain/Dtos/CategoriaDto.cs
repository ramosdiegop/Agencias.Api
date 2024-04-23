using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Domain.Dtos
{
	public class CategoriaDto
	{
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public int? Produosuper { get; set; }
		public int? Cantidad_Campana { get; set; }
		public int? Proxima { get; set; }
		public int? Tope_Por { get; set; }

		public virtual List<SubCategoriaDto>? SubCategorias { get; set; }
	}


	public class SubCategoriaDto { 

		public int Id { get; set; }
		public int Idcategoria { get; set; }
		public int Antiguedad { get; set; }
		public int Tope_Ventas { get; set; }
		public Double Por_ProdPro { get; set; }
		public Double Por_ProdSup { get; set; }
		public Double Por_ProdAge { get; set; }
		public Double Por_AdmiPro { get; set; }
		public Double Por_AdmiSup { get; set; }
		public Double Por_AdmiAge { get; set; }
		

	}
}
