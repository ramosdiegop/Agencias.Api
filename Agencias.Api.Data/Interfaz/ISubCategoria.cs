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
	public interface ISubCategoria
	{
		Task<PagedResponse<List<SubCategoriaDto>>> PostAll(PaginationFilter filter);
		Task<SubCategoria> Create(SubCategoria categoria);
		Task<SubCategoria> Update(SubCategoria categoria);
		Task<string> Delete(int id);
		Task<SubCategoriaDto> GetById(int Id);
	}
}
