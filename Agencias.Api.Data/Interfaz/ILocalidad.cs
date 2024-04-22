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
	public interface ILocalidad
	{
		Task<PagedResponse<List<LocalidadDto>>> PostAll(PaginationFilter filter);
		Task<Localidad> Create(Localidad localidad);
		Task<Localidad> Update(Localidad localidad);
		Task<string> Delete(int id);
		Task<LocalidadDto> GetById(int Id);

	}
}
