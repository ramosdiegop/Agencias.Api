using Agencias.Api.Data.Context;
using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Pagination;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Agencias.Api.Data.Repository
{
	public class EstadoProductorRepository : IEstadoProductor
	{
		private readonly DBContext _Conte;

		public EstadoProductorRepository(DBContext conte)
		{
			_Conte = conte;
		}
		public async Task<PagedResponse<List<EstadoProductor>>> PostAll(PaginationFilter filter)
		{
			var validFilter = new PaginationFilter();
			validFilter.PageNumber = filter.PageNumber;
			validFilter.PageSize = filter.PageSize;
			List<EstadoProductor> LEstado = new List<EstadoProductor>();
			int totalRecords = 0;
			string Elorden = filter.COrder;
			string LaForma = filter.FAscend == true ? "ascending" : "descending";


			var Verify = new FunctionRepository();
			var listaarray = Verify.VerifyArrayFilter(filter.Filtro, filter.Colum);
			filter.Filtro = listaarray[0];
			filter.Colum = listaarray[1];

			if (string.IsNullOrEmpty(filter.COrder))
				Elorden = "Id";

			if (filter.Colum.Count() == 0)
			{
				var Lestado1 = await _Conte.EstadoProductor
										.OrderBy($"{Elorden} {LaForma}")
										.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
										.Take(validFilter.PageSize).ToListAsync();
				//	.Include(i => i.Agencia)
				//	.ThenInclude(i => i.IdlocalidadNavigation).ToListAsync();
				LEstado = Lestado1;
				totalRecords = _Conte.EstadoProductor.Count();
			}
			else
			{
				string[] col = filter.Colum;
				string[] fil = filter.Filtro;
				var predicate = PredicateBuilder.New<EstadoProductor>();

				string fno = "";
				int fid = 0;
				int cont = 0;
				foreach (string item in filter.Colum)
				{
					if (item.ToString().ToUpper() == "ID")
					{
						fid = int.Parse(filter.Filtro[cont].ToString());
						predicate = predicate.And(p => p.Id == fid);
					}
					if (item.ToString().ToUpper() == "DETALLE")
					{
						fno = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Detalle.Contains(fno));

					}


					cont++;
				}

				var Lestado1 = await _Conte.EstadoProductor.Where(predicate)
									.OrderBy($"{Elorden} {LaForma}")
									.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
									.Take(validFilter.PageSize).ToListAsync();
				//.Include(i => i.Agencia)
				//.ThenInclude(i => i.IdlocalidadNavigation).ToListAsync();

				LEstado = Lestado1;

				totalRecords = _Conte.EstadoProductor.Where(predicate).Count();

			}

			var totalPages = decimal.ToInt32(totalRecords / validFilter.PageSize);
			var pagedReponse = new PagedResponse<List<EstadoProductor>>(LEstado, validFilter.PageNumber, validFilter.PageSize, totalPages, totalRecords);


			return pagedReponse;


		}

		public Task<EstadoProductor> GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public async Task<EstadoProductor> Create(EstadoProductor estado)
		{
			await _Conte.EstadoProductor.AddAsync(estado);
			await _Conte.SaveChangesAsync();
			return estado;
		}

		public async Task<string> Delete(int id)
		{
			string error = "Registro eliminado Correctamente ";
			var ElEstado = _Conte.EstadoProductor.Find(id);
			if (ElEstado != null)
			{
				_Conte.EstadoProductor.Remove(ElEstado);
				await _Conte.SaveChangesAsync();
			}
			else error = "No se encontro el registro";
			return error;

		}


		public async Task<EstadoProductor> Update(EstadoProductor estado)
		{
			_Conte.EstadoProductor.Update(estado);
			await _Conte.SaveChangesAsync();
			return estado;

		}

		public async Task<List<EstadoProductor>> GetAllSelect()
		{
			var Lestado = await _Conte.EstadoProductor.ToListAsync();

			return Lestado;

		}



	}
}
