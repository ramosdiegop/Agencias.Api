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
	public class AgenteRepository : IAgente
	{
		private readonly DBContext _Conte;

		public AgenteRepository(DBContext conte)
		{
			_Conte = conte;
		}
		public async Task<PagedResponse<List<AgenteDto>>> PostAll(PaginationFilter filter)
		//public async Task<List<AgenteDto>> GetAll()
		{
			var validFilter = new PaginationFilter();
			validFilter.PageNumber = filter.PageNumber;
			validFilter.PageSize = filter.PageSize;
			List<Agente> Lagente = new List<Agente>();
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
				var Lagente1 = await _Conte.Agente
										.OrderBy($"{Elorden} {LaForma}")
										.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
										.Take(validFilter.PageSize).ToListAsync();
				//	.Include(i => i.Agencia)
				//	.ThenInclude(i => i.IdlocalidadNavigation).ToListAsync();
				Lagente = Lagente1;
				totalRecords = _Conte.Agente.Count();
			}
			else
			{
				string[] col = filter.Colum;
				string[] fil = filter.Filtro;
				var predicate = PredicateBuilder.New<Agente>();

				string fno, fcu = "";
				int fid = 0;
				int cont = 0;
				foreach (string item in filter.Colum)
				{
					if (item.ToString().ToUpper() == "ID")
					{
						fid = int.Parse(filter.Filtro[cont].ToString());
						predicate = predicate.And(p => p.Id == fid);
					}
					if (item.ToString().ToUpper() == "NOMBRE")
					{
						fno = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Nombre.Contains(fno));

					}
					if (item.ToString().ToUpper() == "CUIT")
					{
						fcu = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Cuit.Contains(fcu));
					}

					cont++;
				}

				var Lagente1 = await _Conte.Agente.Where(predicate)
									.OrderBy($"{Elorden} {LaForma}")
									.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
									.Take(validFilter.PageSize).ToListAsync();
				//.Include(i => i.Agencia)
				//.ThenInclude(i => i.IdlocalidadNavigation).ToListAsync();

				Lagente = Lagente1;

				totalRecords = _Conte.Agente.Where(predicate).Count();

			}


			List<AgenteDto> dtoAgente = new List<AgenteDto>();

			foreach (var item in Lagente)
			{
				List<AgenteAgencia> Aagente = new List<AgenteAgencia>();

				/*				foreach (var iteml in item.Agencia)
								{
									var UnaAgencia = new AgenteAgencia
									{
										Id = iteml.Id,
										Idagencia = iteml.Idagencia,
										Nombre = iteml.Nombre,
										Direccion = iteml.Direccion,
										Localidad = (iteml.IdlocalidadNavigation.CodigoPostal==null) ? " " : iteml.IdlocalidadNavigation.CodigoPostal.ToString() +"-"+ iteml.IdlocalidadNavigation.Detalle,						
										Titular = iteml.Titular,	
										Cuit = iteml.Cuit,
										Llave = iteml.Llave,
										Ok	=	iteml.Ok,
										Banco = iteml.Banco
									};
									Aagente.Add(UnaAgencia);
								}*/

				var UnAgente = new AgenteDto
				{
					Id = item.Id,
					Nombre = item.Nombre,
					Cuit = item.Cuit,
					Created_Date = item.Created_Date,
					Created_User = item.Created_User,
					Modified_Date = item.Modified_Date,
					Modified_User = item.Modified_User
					//agenteAgencias = Aagente
				};
				dtoAgente.Add(UnAgente);

			}

			var totalPages = decimal.ToInt32(totalRecords / validFilter.PageSize);
			var pagedReponse = new PagedResponse<List<AgenteDto>>(dtoAgente, validFilter.PageNumber, validFilter.PageSize, totalPages, totalRecords);



			return pagedReponse;


		}

		public Task<AgenteDto> GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public async Task<Agente> Create(Agente agente)
		{
			await _Conte.Agente.AddAsync(agente);
			await _Conte.SaveChangesAsync();
			return agente;
		}

		public async Task<string> Delete(int id)
		{
			string error = "Registro eliminado Correctamente ";
			var Elagente = _Conte.Agente.Find(id);
			if (Elagente != null)
			{
				_Conte.Agente.Remove(Elagente);
				await _Conte.SaveChangesAsync();
			}
			else error = "No se encontro el registro";
			return error;

		}


		public async Task<Agente> Update(Agente agente)
		{
			_Conte.Agente.Update(agente);
			await _Conte.SaveChangesAsync();
			return agente;

		}

		async Task<List<Agente>> IAgente.GetAllSelect()
		{
			var Lagente = await _Conte.Agente.ToListAsync();

			return Lagente;

		}
	}
}
