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
	public interface IAgente
	{
		//Task<List<AgenteDto>> GetAll();
		Task<PagedResponse<List<AgenteDto>>> PostAll(PaginationFilter filter);
		Task<List<Agente>> GetAllSelect();
		Task<Agente> Create(Agente agente);
		Task<Agente> Update(Agente agente);
		Task<string> Delete(int id);
		Task<AgenteDto> GetById(int Id);
		//Task<T> Update(int id);

	}
}
