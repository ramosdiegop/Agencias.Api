using Agencias.Api.Data.Data;
using Agencias.Api.Domain.Dtos;
using Agencias.Api.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Interfaz
{
	public interface IMenu
	{
		Task<PagedResponse<List<MenuDto>>> PostAll(PaginationFilter filter);
		Task<List<Menu>> GetAllSelect();
		Task<Menu> Create(Menu menu);
		Task<Menu> Update(Menu menu);
		Task<string> Delete(int id);
		Task<Menu> GetById(int Id);
		Task<List<MenuDto>> GetByUsuario(int idusuario);

		
	}
}
