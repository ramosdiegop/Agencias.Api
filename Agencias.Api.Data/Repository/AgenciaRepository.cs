using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Dtos;
using Agencias.Api.Domain.Pagination;
using Agencias.Api.Data.Context;
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
	public class AgenciaRepository : IAgencia
	{
		private DBContext _Conte;

		public AgenciaRepository(DBContext conte)
		{
			_Conte = conte;
		}

		//public async Task<List<AgenciaDto>> GetAll(PaginationFilter filter)
		public async Task<PagedResponse<List<AgenciaDto>>> PostAll(PaginationFilter filter)
		{


			var validFilter = new PaginationFilter();
			validFilter.PageNumber = filter.PageNumber;
			validFilter.PageSize = filter.PageSize;
			List<Agencia> Lagencia = new List<Agencia>();
			int totalRecords = 0;
			string Elorden = filter.COrder;
			string LaForma = filter.FAscend == true ? "ascending" : "descending";

			var Verify = new FunctionRepository();
			var listaarray = Verify.VerifyArrayFilter(filter.Filtro, filter.Colum);
			filter.Filtro = listaarray[0];
			filter.Colum = listaarray[1];


			if (string.IsNullOrEmpty(filter.COrder))
				Elorden = "Idagencia";

			if (filter.Colum.Count() == 0)
			{
				var Lagencia1 = await _Conte.Agencia
								   .OrderBy($"{Elorden} {LaForma}")
								   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
								   .Take(validFilter.PageSize)
								   .Include(i => i.Localidad).ThenInclude(e => e.Provincia)
								   .Include(a => a.Agente).ToListAsync();
				//								   .OrderBy(o => o.Idagencia).ToListAsync();
				Lagencia = Lagencia1;
				totalRecords = _Conte.Agencia.Count();
			}
			else
			{
				//List<Agencia> Lagencia2 = new List<Agencia>();
				string[] col = filter.Colum;
				string[] fil = filter.Filtro;
				var predicate = PredicateBuilder.New<Agencia>();

				string fno, fdi, flo, fti, fcu, fba, fag = "";
				int fid, fagid = 0;
				int cont = 0;
				foreach (string item in filter.Colum)
				{
					if (item.ToString().ToUpper() == "IDAGENCIA")
					{
						fid = int.Parse(filter.Filtro[cont].ToString());
						//predicate = predicate.And(p => p.Idagencia.ToString().Contains(fid));
						predicate = predicate.And(p => p.Idagencia == fid);
					}
					if (item.ToString().ToUpper() == "NOMBRE")
					{
						fno = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Nombre.Contains(fno));

					}

					if (item.ToString().ToUpper() == "DIRECCION")
					{
						fdi = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Direccion.Contains(fdi));
					}
					if (item.ToString().ToUpper() == "LOCALIDAD")
					{
						flo = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Localidad.Detalle.Contains(flo));
					}
					if (item.ToString().ToUpper() == "TITULAR")
					{
						fti = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Titular.Contains(fti));

					}
					if (item.ToString().ToUpper() == "CUIT")
					{
						fcu = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Cuit.Contains(fcu));
					}
					if (item.ToString().ToUpper() == "BANCO")
					{
						fba = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Banco.Contains(fba));
					}
					if (item.ToString().ToUpper() == "AGENTE")
					{
						fag = filter.Filtro[cont].ToString();
						predicate = predicate.And(p => p.Agente.Nombre.Contains(fag));
					}

					if (item.ToString().ToUpper() == "IDAGENTE")
					{
						fagid = int.Parse(filter.Filtro[cont].ToString());
						predicate = predicate.And(p => p.Idagente == fagid);
					}

					cont++;
				}
				//int cont = 0;
				//predicate = predicate.And(p => p.Idagencia.ToString().Contains(filter.Filtro[cont].ToString()));



				var Lagencia2 = await _Conte.Agencia.Where(predicate)
						.OrderBy($"{Elorden} {LaForma}")
						.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
						.Take(validFilter.PageSize)
						.Include(i => i.Localidad).ThenInclude(e => e.Provincia)
						.Include(a => a.Agente).ToListAsync();
				//.OrderBy(o => o.Idagencia);

				totalRecords = _Conte.Agencia.Where(predicate).Count();
				/*------------*/

				Lagencia = Lagencia2;

			}


			List<AgenciaDto> dtoAgencia = new List<AgenciaDto>();
			foreach (var item in Lagencia)
			{
				var UnaAgencia = new AgenciaDto
				{
					Id = item.Id,
					Idagencia = item.Idagencia,
					Nombre = item.Nombre,
					Direccion = item.Direccion,
					Idlocalidad = item.Idlocalidad,
					Titular = item.Titular,
					Cuit = item.Cuit,
					Llave = item.Llave,
					Banco = item.Banco,
					Idagente = item.Idagente,
					Localidad = (item.Localidad.CodigoPostal == null) ? " " : item.Localidad.CodigoPostal.ToString() + "-" + item.Localidad.Detalle,
					Agente = item.Agente.Nombre,
					Created_Date = item.Created_Date,
					Created_User = item.Created_User,
					Modified_Date = item.Modified_Date,
					Modified_User = item.Modified_User

				};
				dtoAgencia.Add(UnaAgencia);

			}

			var totalPages = decimal.ToInt32(totalRecords / validFilter.PageSize);
			var pagedReponse = new PagedResponse<List<AgenciaDto>>(dtoAgencia, validFilter.PageNumber, validFilter.PageSize, totalPages, totalRecords);

			return pagedReponse;

		}

		public async Task<Agencia> Create(Agencia agencia)
		{
			await _Conte.Agencia.AddAsync(agencia);
			await _Conte.SaveChangesAsync();
			return agencia;
		}

		public async Task<string> Delete(int id)
		{
			string error = "Registro eliminado Correctamente ";
			var LaAgencia = _Conte.Agencia.Find(id);
			if (LaAgencia != null)
			{
				_Conte.Agencia.Remove(LaAgencia);
				await _Conte.SaveChangesAsync();
			}
			else error = "No se encontro el registro";
			return error;
		}


		public async Task<AgenciaDto> GetById(int Id)
		{
			var Lagencia = await _Conte.Agencia.Include(i => i.Localidad).ThenInclude(e => e.Provincia)
										.Include(a => a.Agente)
										.OrderBy(o => o.Id).FirstOrDefaultAsync();


			var UnaAgencia = new AgenciaDto
			{
				Id = Lagencia.Id,
				Idagencia = Lagencia.Idagencia,
				Nombre = Lagencia.Nombre,
				Direccion = Lagencia.Direccion,
				Idlocalidad = Lagencia.Idlocalidad,
				Titular = Lagencia.Titular,
				Cuit = Lagencia.Cuit,
				Llave = Lagencia.Llave,
				Banco = Lagencia.Banco,
				Idagente = Lagencia.Idagente,
				Localidad = (Lagencia.Localidad.CodigoPostal == null) ? " " : Lagencia.Localidad.CodigoPostal.ToString() + "-" + Lagencia.Localidad.Detalle,
				Agente = Lagencia.Agente.Nombre

			};


			return UnaAgencia;
		}


		public async Task<Agencia> Update(Agencia agencia)
		{
			_Conte.Agencia.Update(agencia);
			await _Conte.SaveChangesAsync();
			return agencia;
		}


	}
}
