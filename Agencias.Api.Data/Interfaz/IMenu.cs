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
		Task<PagedResponse<List<Menu>>> PostAll(PaginationFilter filter);
		Task<List<MenuUsuario>> GetAllSelect(int idusuario);
		Task<Menu> Create(Menu menu);
		Task<Menu> Update(Menu menu);
		Task<string> Delete(int id);
		Task<Menu> GetById(int Id);
		Task<List<MenuDto>> GetByUsuario(int idusuario);
		Task<MenuUsuario> CreateAcceso(MenuUsuario acceso);
		Task<MenuUsuario> UpdateAcceso(MenuUsuario acceso);
		Task<string> DeleteAcceso(int accesoid);


	}
}
