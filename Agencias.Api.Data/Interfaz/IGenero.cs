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
	public interface IGenero
	{
		Task<PagedResponse<List<Genero>>> PostAll(PaginationFilter filter);
		Task<List<Genero>> GetAllSelect();
		Task<Genero> Create(Genero genero);
		Task<Genero> Update(Genero genero);
		Task<string> Delete(int id);
		Task<Genero> GetById(int Id);

	}
}
