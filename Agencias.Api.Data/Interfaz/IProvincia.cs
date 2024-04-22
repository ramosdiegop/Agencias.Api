using Agencias.Api.Data.Data;
using Agencias.Api.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Interfaz
{
	public interface IProvincia
	{
		//Task<List<AgenteDto>> GetAll();
		Task<PagedResponse<List<Provincia>>> PostAll(PaginationFilter filter);
		Task<List<Provincia>> GetAllSelect();
		Task<Provincia> Create(Provincia provin);
		Task<Provincia> Update(Provincia provin);
		Task<string> Delete(int id);
		Task<Provincia> GetById(int Id);
		//Task<T> Update(int id);

	}
}
