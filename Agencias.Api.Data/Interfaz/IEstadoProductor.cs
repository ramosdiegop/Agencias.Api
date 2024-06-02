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
	public interface IEstadoProductor
	{

		Task<PagedResponse<List<EstadoProductor>>> PostAll(PaginationFilter filter);
		Task<List<EstadoProductor>> GetAllSelect();
		Task<EstadoProductor> Create(EstadoProductor estadoprod);
		Task<EstadoProductor> Update(EstadoProductor estadoprod);
		Task<string> Delete(int id);
		Task<EstadoProductor> GetById(int Id);

	}
}
