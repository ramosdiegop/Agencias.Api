using Agencias.Api.Authentication;
using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agencias.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authenticate]
	public class EstadoProductorController : ControllerBase
	{
		private readonly IEstadoProductor _IEstado;
		public EstadoProductorController(IEstadoProductor IEstado)
		{
			_IEstado = IEstado;
		}
		// GETAll: api Lista generos/
		[HttpPost]
		public async Task<ActionResult<PagedResponse<List<IEstadoProductor>>>> PostAll([FromBody] PaginationFilter filter)
		{
			try
			{
				var Lestado = await _IEstado.PostAll(filter);
				return Ok(Lestado);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}


		[HttpGet("{select}")]
		public async Task<ActionResult<IEnumerable<EstadoProductor>>> GetAllSelect()
		{
			try
			{
				var Lestado = await _IEstado.GetAllSelect();
				return Ok(Lestado);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}



		[HttpPut]
		public async Task<ActionResult<EstadoProductor>> Put(EstadoProductor estado)
		{

			try
			{
				var ELestado = await _IEstado.Update(estado);
				return Ok(ELestado);
			}
			catch (Exception e)
			{

				return NotFound("Error: " + e.Message);
			}

		}

		[HttpPost("{id}")]
		public async Task<ActionResult<EstadoProductor>> Post(EstadoProductor estado)
		{
			EstadoProductor Elestado;
			try
			{
				Elestado = await _IEstado.Create(estado);
				return Ok(Elestado);
			}
			catch (Exception e)
			{

				return NotFound("Error: " + e.Message);
			}


		}


		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				string resultado = await _IEstado.Delete(id);
				return Ok(resultado);

			}
			catch (Exception e)
			{
				return NotFound(e.Message);

			}

		}
	}
}
