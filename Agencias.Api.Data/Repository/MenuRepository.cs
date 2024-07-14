using Agencias.Api.Data.Context;
using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Dtos;
using Agencias.Api.Domain.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			var Lmenu = await _Conte.Menues.ToListAsync();

			List<MenuDto> dtoMenu = new List<MenuDto>();
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

		public async Task<List<Menu>> GetAllSelect()
		{
			throw new NotImplementedException();
		}

		public async Task<Menu> GetById(int Id)
		{
			throw new NotImplementedException();
		}


		public async Task<PagedResponse<List<MenuDto>>> PostAll(PaginationFilter filter)
		{
			throw new NotImplementedException();
		}

		public async Task<Menu> Update(Menu menu)
		{
			throw new NotImplementedException();
		}


	}
}
