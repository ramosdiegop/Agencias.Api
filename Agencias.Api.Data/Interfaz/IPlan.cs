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
	public interface IPlan
	{

		Task<PagedResponse<List<Plan>>> PostAll(PaginationFilter filter);
		Task<List<Plan>> GetAllSelect();
		Task<Plan> Create(Plan plan);
		Task<Plan> Update(Plan plan);
		Task<string> Delete(int id);
		Task<Plan> GetById(int Id);

	}
}
