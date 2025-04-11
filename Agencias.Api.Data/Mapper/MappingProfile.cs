using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Mapper
{
	public class MappingProfile : IMapping
	{

		public Agencia MappAgencia(AgenciaDto amap)
		{
			var age = new Agencia
			{
				Id = amap.Id,
				Idagencia = amap.Idagencia,
				Nombre = amap.Nombre,
				Direccion = amap.Direccion,
				Idlocalidad = amap.Idlocalidad,
				Titular = amap.Titular,
				Cuit = amap.Cuit,
				Llave = amap.Llave,
				Ok = amap.Ok,
				Banco = amap.Banco,
				Idagente = amap.Idagente
			};

			return age;
		}


		public Categoria MappCategoria(CategoriaDto cmap)
		{
			var cate = new Categoria
			{
				Id = cmap.Id,
				Nombre = cmap.Nombre,
				ProduOSuper = cmap.Produosuper,
				Proxima = cmap.Proxima,	
				Tope_por = cmap.Tope_Por,
				Cantidad_Campana = cmap.Cantidad_Campana	
			};

			return cate;
		}


		public List<ItemDto> MappMenu(List<MenuDto> menu)
		{
			List<ItemDto> L_menu = new List<ItemDto>();

			//Menu
			foreach (MenuDto m in menu) { 

				if (m.Esmenu == "SI")
				{
					var i_menu = new ItemDto
					{
						label = m.Nombre,
						icon = null,
						routerLink = m.link,
						items = null,
						Id = (int)m.Idmenu

					};
					L_menu.Add(i_menu);
				}
			}

			//options
			foreach (MenuDto m in menu)
			{
				if (m.Esmenu == "NO")
				{
					var i_menu = new ItemDto
					{
						label = m.Nombre,
						icon = null,
						routerLink = m.link,
						items = null,
						Id = m.Id,
					};

					
					var opmenu = L_menu.Find(x => x.Id == m.Idmenu);
					var index = L_menu.IndexOf(opmenu);
					if (index != -1)
					{
						List<ItemDto> Litems = new List<ItemDto>();
						if (opmenu.items != null)
							Litems = opmenu.items;
						Litems.Add(i_menu);
						opmenu.items=Litems;

						L_menu[index] = opmenu;
					}



				}

			}


			return L_menu;
		}


		public List<MenuAccesosDto> MappMenuCrud(List<Menu> menu) 
		{
			List<MenuAccesosDto> L_menu = new List<MenuAccesosDto>();

			//Menu
			foreach (Menu m in menu)
			{
				if (m.Esmenu == "SI")
				{
					var datamenu = new DataMenu();
					datamenu.name = m.Nombre;
					var i_menu = new MenuAccesosDto
					{
						key = m.Id.ToString()+"-0",
						data = datamenu,
						children = null

					};
					L_menu.Add(i_menu);
				}
			}

			//options
			foreach (Menu m in menu)
			{
				if (m.Esmenu == "NO")
				{
					var datamenu = new DataMenu();
					datamenu.name = m.Nombre;
					var i_menu = new MenuAccesosDto
					{
						key = m.Idmenu.ToString() + "-"+m.Id.ToString(),
						data = datamenu,
						children = null
					};


					var opmenu = L_menu.Find(x => x.key == m.Idmenu.ToString() + "-0");
					var index = L_menu.IndexOf(opmenu);
					if (index != -1)
					{
						List<MenuAccesosDto> Litems = new List<MenuAccesosDto>();
						if (opmenu.children != null)
							Litems = opmenu.children;
						Litems.Add(i_menu);
						opmenu.children = Litems;

						L_menu[index] = opmenu;
					}



				}

			}


			return L_menu;



			return L_menu;
		}

	}
}
