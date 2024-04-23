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
	public class CategoriaRepository : ICategoria
	{
		private DBContext _Conte;

		public CategoriaRepository(DBContext conte) {
			_Conte = conte;
		}

		public async Task<PagedResponse<List<CategoriaDto>>> PostAll(PaginationFilter filter)
		{
			var validFilter = new PaginationFilter();
			validFilter.PageNumber = filter.PageNumber;
			validFilter.PageSize = filter.PageSize;
			List<Categoria> LCategoria = new List<Categoria>();
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
				var LCategoria1 = await _Conte.Categoria
								   .OrderBy($"{Elorden} {LaForma}")
								   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
								   .Take(validFilter.PageSize)
								   .Include(i => i.SubCategorias)
								   .ToListAsync();

				LCategoria = LCategoria1;
				totalRecords = _Conte.Categoria.Count();
			}
			else
			{
				//List<Agencia> Lagencia2 = new List<Agencia>();
				string[] col = filter.Colum;
				string[] fil = filter.Filtro;
				var predicate = PredicateBuilder.New<Categoria>();
				
				string fno = "";
				int fid, fps = 0;
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

					cont++;
				}


				var LCategoria2 = await _Conte.Categoria.Where(predicate)
						.OrderBy($"{Elorden} {LaForma}")
						.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
						.Take(validFilter.PageSize)
						.Include(i => i.SubCategorias).ToListAsync();

				totalRecords = _Conte.Categoria.Where(predicate).Count();
				/*------------*/

				LCategoria = LCategoria2;

			}
			
			List<CategoriaDto> dtoCategoria = new List<CategoriaDto>();
			foreach (var item in LCategoria)
			{

				List<SubCategoriaDto> sub = new List<SubCategoriaDto>();
				foreach (var item1 in item.SubCategorias)
				{
					var lsub = new SubCategoriaDto
					{
						Id = item1.Id,
						Idcategoria = item1.Idcategoria,
						Antiguedad = item1.Antiguedad,
						Tope_Ventas = item1.Tope_Ventas,
						Por_ProdPro = item1.Por_ProdPro,
						Por_ProdSup = item1.Por_ProdSup,
						Por_ProdAge = item1.Por_ProdAge,
						Por_AdmiPro = item1.Por_AdmiPro,
						Por_AdmiSup = item1.Por_AdmiSup,
						Por_AdmiAge = item1.Por_AdmiAge,

					};
					sub.Add(lsub);
				}

				var OneCategoria = new CategoriaDto
				{
					Id = item.Id,
					Nombre = item.Nombre,
					Produosuper = item.ProduOSuper,
					Cantidad_Campana = item.Cantidad_Campana,
					Proxima = item.Proxima,
					Tope_Por = (item.Tope_por == null) ? 0 : item.Tope_por,
					SubCategorias = sub


				};


				dtoCategoria.Add(OneCategoria);

			};


			var totalPages = decimal.ToInt32(totalRecords / validFilter.PageSize);
			var pagedReponse = new PagedResponse<List<CategoriaDto>>(dtoCategoria, validFilter.PageNumber, validFilter.PageSize, totalPages, totalRecords);

			return pagedReponse;
						
		}


		public async Task<Categoria> Create(Categoria categoria)
		{
			await _Conte.Categoria.AddAsync(categoria);
			await _Conte.SaveChangesAsync();
			return categoria;
		}

		public async Task<string> Delete(int id)
		{
			string error = "Registro eliminado Correctamente ";
			var LaCategoria = _Conte.Categoria.Find(id);
			if (LaCategoria != null)
			{
				_Conte.Categoria.Remove(LaCategoria);
				await _Conte.SaveChangesAsync();
			}
			else error = "No se encontro el registro";
			return error;

		}


		public async Task<Categoria> Update(Categoria categopria)
		{
			_Conte.Categoria.Update(categopria);
			await _Conte.SaveChangesAsync();
			return categopria;

		}

		Task<Categoria> ICategoria.Create(Categoria categoria)
		{
			throw new NotImplementedException();
		}

		Task<CategoriaDto> ICategoria.GetById(int Id)
		{
			throw new NotImplementedException();
		}
	}
}
