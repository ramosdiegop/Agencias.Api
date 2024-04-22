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
	public interface ICategoria
	{
		Task<PagedResponse<List<CategoriaDto>>> PostAll(PaginationFilter filter);
		Task<Categoria> Create(Categoria categoria);
		Task<Categoria> Update(Categoria categoria);
		Task<string> Delete(int id);
		Task<CategoriaDto> GetById(int Id);
	}
}
