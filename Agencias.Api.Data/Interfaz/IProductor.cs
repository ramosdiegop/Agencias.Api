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
	public interface IProductor
	{ 
		Task<PagedResponse<List<ProductorDto>>> PostAll(PaginationFilter filter);
		Task<Productor> Create(Productor produc);
		Task<Productor> Update(Productor produc);
		Task<string> Delete(int id);
		Task<ProductorDto> GetById(int Id);
	}
}
