using Agencias.Api.Data.Context;
using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Dtos;
using Agencias.Api.Domain.Pagination;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Repository
{
	public class SubCategoriaRepository : ISubCategoria
	{
		private DBContext _Conte;

		public SubCategoriaRepository(DBContext conte) {
			_Conte = conte;
		}

		public async Task<PagedResponse<List<SubCategoriaDto>>> PostAll(PaginationFilter filter)
		{
			var validFilter = new PaginationFilter();
			validFilter.PageNumber = filter.PageNumber;
			validFilter.PageSize = filter.PageSize;
			List<SubCategoria> LSubCategoria = new List<SubCategoria>();
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
				var LSubCategoria1 = await _Conte.SubCategoria
								   .OrderBy($"{Elorden} {LaForma}")
								   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
								   .Take(validFilter.PageSize)
								   .ToListAsync();

				LSubCategoria = LSubCategoria1;
				totalRecords = _Conte.Categoria.Count();
			}
			else
			{
				//List<Agencia> Lagencia2 = new List<Agencia>();
				string[] col = filter.Colum;
				string[] fil = filter.Filtro;
				var predicate = PredicateBuilder.New<Categoria>();
				
				string fno = "";
				int fid, fps,ftp = 0;
				int cont = 0;
				foreach (string item in filter.Colum)
				{
					if (item.ToString().ToUpper() == "ID")
					{
						fid = int.Parse(filter.Filtro[cont].ToString());
						//predicate = predicate.And(p => p.Idagencia.ToString().Contains(fid));
						predicate = predicate.And(p => p.Id == fid);
					}
					if (item.ToString().ToUpper() == "NOMBRE")
					{
						fno = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Nombre.Contains(fno));
					}

					if (item.ToString().ToUpper() == "PRODUOSUPER")
					{
						fps = int.Parse(filter.Filtro[cont].ToString()); ;
						predicate = predicate.And(p => p.ProduOSuper == fps);
					}

					if (item.ToString().ToUpper() == "TOPE_POR")
					{						
						ftp = int.Parse(filter.Filtro[cont].ToString()); ;
						predicate = predicate.And(p => ((p.Tope_por==null)?0: p.Tope_por) == ftp);
					}

					cont++;
				}


				var LSubCategoria2 = await _Conte.SubCategoria.Where(predicate)
						.OrderBy($"{Elorden} {LaForma}")
						.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
						.Take(validFilter.PageSize)
						.ToListAsync();

				totalRecords = _Conte.Categoria.Where(predicate).Count();
				/*------------*/

				LSubCategoria = LSubCategoria2;

			}
			
			List<SubCategoriaDto> dtoCategoria = new List<SubCategoriaDto>();
			foreach (var item in LSubCategoria)
			{

				var lsub = new SubCategoriaDto
				{
					Id = item.Id,
					Idcategoria = item.Idcategoria,
					Antiguedad = item.Antiguedad,
					Tope_Ventas = item.Tope_Ventas,
					Por_ProdPro = item.Por_ProdPro,
					Por_ProdSup = item.Por_ProdSup,
					Por_ProdAge = item.Por_ProdAge,
					Por_AdmiPro = item.Por_AdmiPro,
					Por_AdmiSup = item.Por_AdmiSup,
					Por_AdmiAge = item.Por_AdmiAge,
				};


				dtoCategoria.Add(lsub);

			};


			var totalPages = decimal.ToInt32(totalRecords / validFilter.PageSize);
			var pagedReponse = new PagedResponse<List<SubCategoriaDto>>(dtoCategoria, validFilter.PageNumber, validFilter.PageSize, totalPages, totalRecords);

			return pagedReponse;
						
		}


		public async Task<SubCategoria> Create(SubCategoria subcategoria)
		{

			try
			{
				_Conte.SubCategoria.Add(subcategoria);
				await _Conte.SaveChangesAsync();
				return subcategoria;

			}
			catch (Exception)
			{

				throw;
			}


		}

		public async Task<string> Delete(int id)
		{
			string error = "Registro eliminado Correctamente ";
			var LaSubCategoria = _Conte.SubCategoria.Find(id);
			if (LaSubCategoria != null)
			{
				_Conte.SubCategoria.Remove(LaSubCategoria);
				await _Conte.SaveChangesAsync();
			}
			else error = "No se encontro el registro";
			return error;

		}


		public async Task<SubCategoria> Update(SubCategoria subcategoria)
		{
			_Conte.SubCategoria.Update(subcategoria);
			await _Conte.SaveChangesAsync();
			return subcategoria;


		}

		public async Task<SubCategoriaDto> GetById(int Id)
		{
			throw new NotImplementedException();
		}
	}
}
