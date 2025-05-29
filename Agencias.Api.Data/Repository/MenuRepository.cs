using Agencias.Api.Data.Context;
using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Dtos;
using Agencias.Api.Domain.Pagination;
using Microsoft.EntityFrameworkCore;
using System;


namespace Agencias.Api.Data.Repository
{
	public class MenuRepository : IMenu
	{
		private readonly DBContext _Conte;

		public MenuRepository(DBContext conte)
		{
			_Conte = conte;
		}


		public async Task<List<MenuDto>> GetByUsuario(int idusuario)
		{
			/*var Lmenu = await _Conte.Menues.ToListAsync();*/
			List<MenuDto> dtoMenu = new List<MenuDto>();

			if (idusuario != 0)
			{
				var Lmenu = await _Conte.MenuUsuarios
										.Where(w => w.Usuario_id == idusuario)
										.Include(i => i.Menues)
										.ToListAsync();

				
				foreach (var item in Lmenu)
				{
					var unmenu = new MenuDto
					{
						Id = item.Id,
						Nombre = item.Menues.Nombre,
						Esmenu = item.Menues.Esmenu,
						EsSubmenu = item.Menues.EsSubmenu,
						Eslink = item.Menues.Eslink,
						Idmenu = item.Menues.Idmenu,
						Idsubmenu = item.Menues.Idsubmenu,
						link = item.Menues.link,
						Ejecutable = item.Menues.Ejecutable,

					};
					dtoMenu.Add(unmenu);

				}
			}
			else
			{
				var Lmenu = await _Conte.Menues
										.ToListAsync();

				foreach (var item in Lmenu)
				{
					var unmenu = new MenuDto
					{
						Id = item.Id,
						Nombre = item.Nombre,
						Esmenu = item.Esmenu,
						EsSubmenu = item.EsSubmenu,
						Eslink = item.Eslink,
						Idmenu = item.Idmenu,
						Idsubmenu = item.Idsubmenu,
						link = item.link,
						Ejecutable = item.Ejecutable,

					};
					dtoMenu.Add(unmenu);

				}

			}


			return dtoMenu;

		}


		public async Task<Menu> Create(Menu menu)
		{
			throw new NotImplementedException();
		}

		public async Task<string> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Menu>> GetAllSelect(int idusuario)
		{
			List<Menu> Lmenu = new List<Menu>();
			if (idusuario == 0)
				Lmenu = await _Conte.Menues.ToListAsync();
			else
			{
				var usuariomenu = await _Conte.MenuUsuarios
									.Where(w => w.Usuario_id == idusuario)
									.Include(i => i.Menues)
									.ToListAsync();

				foreach (var item in usuariomenu)
				{					
					Lmenu.Add(item.Menues);
				}
				

			}
				

			return Lmenu;
		}

		public async Task<Menu> GetById(int Id)
		{
			Menu Lmenu = new Menu();
			Lmenu = await _Conte.Menues
						.Where(w => w.Id == Id)
						.FirstOrDefaultAsync();

			return Lmenu;
		}


		public async Task<PagedResponse<List<Menu>>> PostAll(PaginationFilter filter)
		{
			throw new NotImplementedException();
		}

		public async Task<Menu> Update(Menu menu)
		{
			throw new NotImplementedException();
		}


	}
}
