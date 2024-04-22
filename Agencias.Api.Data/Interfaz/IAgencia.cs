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
	public interface IAgencia
	{
		Task<PagedResponse<List<AgenciaDto>>> PostAll(PaginationFilter filter);
		Task<Agencia> Create(Agencia agencia);
		Task<Agencia> Update(Agencia agencia);
		Task<string> Delete(int id);
		Task<AgenciaDto> GetById(int Id);

	}
}
