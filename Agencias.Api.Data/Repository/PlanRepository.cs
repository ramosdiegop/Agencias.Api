using Agencias.Api.Data.Context;
using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Pagination;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Agencias.Api.Data.Repository
{
	public class PlanRepository : IPlan
	{
		private readonly DBContext _Conte;

		public PlanRepository(DBContext conte)
		{
			_Conte = conte;
		}
		public async Task<PagedResponse<List<Plan>>> PostAll(PaginationFilter filter)
		{
			var validFilter = new PaginationFilter();
			validFilter.PageNumber = filter.PageNumber;
			validFilter.PageSize = filter.PageSize;
			List<Plan> Lplan = new List<Plan>();
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
				var Lplan1 = await _Conte.Plan
										.OrderBy($"{Elorden} {LaForma}")
										.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
										.Take(validFilter.PageSize).ToListAsync();

				Lplan = Lplan1;
				totalRecords = _Conte.Plan.Count();
			}
			else
			{
				string[] col = filter.Colum;
				string[] fil = filter.Filtro;
				var predicate = PredicateBuilder.New<Plan>();

				string fno = "";
				int fid,fco = 0;
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

					if (item.ToString().ToUpper() == "CODIGO")
					{
						fco = int.Parse(filter.Filtro[cont].ToString());
						predicate = predicate.And(p => p.Codigo==(fco));

					}
					cont++;
				}

				var Lplan1 = await _Conte.Plan.Where(predicate)
									.OrderBy($"{Elorden} {LaForma}")
									.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
									.Take(validFilter.PageSize).ToListAsync();

				Lplan = Lplan1;

				totalRecords = _Conte.Plan.Where(predicate).Count();

			}

			var totalPages = decimal.ToInt32(totalRecords / validFilter.PageSize);
			var pagedReponse = new PagedResponse<List<Plan>>(Lplan, validFilter.PageNumber, validFilter.PageSize, totalPages, totalRecords);


			return pagedReponse;


		}

		public Task<Genero> GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public async Task<Plan> Create(Plan plan)
		{
			await _Conte.Plan.AddAsync(plan);
			await _Conte.SaveChangesAsync();
			return plan;
		}

		public async Task<string> Delete(int id)
		{
			string error = "Registro eliminado Correctamente ";
			var Elplan = _Conte.Plan.Find(id);
			if (Elplan != null)
			{
				_Conte.Plan.Remove(Elplan);
				await _Conte.SaveChangesAsync();
			}
			else error = "No se encontro el registro";
			return error;

		}


		public async Task<Plan> Update(Plan plan)
		{
			_Conte.Plan.Update(plan);
			await _Conte.SaveChangesAsync();
			return plan;

		}

		public async Task<List<Plan>> GetAllSelect()
		{
			var Lplan = await _Conte.Plan.ToListAsync();

			return Lplan;

		}

		Task<Plan> IPlan.GetById(int Id)
		{
			throw new NotImplementedException();
		}
	}
}
