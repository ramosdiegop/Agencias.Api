using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Domain.Dtos
{
	public class MenuDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Esmenu { get; set; }
		public string EsSubmenu { get; set; }
		public string Eslink { get; set; }
		public string Ejecutable { get; set; }
		public int? Idmenu { get; set; }
		public int? Idsubmenu { get; set; }
		public string? link { get; set; }

	}

	public class menues
	{
		public item items { get; set; }


	}


	public class item {
		public string label { get; set; }
        public string icon { get; set; }
        public string routerLink { get; set; }
	
	}

}
