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
	public interface IUsuario
	{
		Task<PagedResponse<List<Usuario>>> PostAll(PaginationFilter filter);
		Task<List<Usuario>> GetAllSelect();
		Task<Usuario> Create(Usuario usuario);
		Task<Usuario> Update(Usuario usuario);
		Task<string> Delete(int id);
		Task<Usuario> GetById(int Id);

	}
}
