using Agencias.Api.Data.Data;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Domain.Dtos;
using Agencias.Api.Domain.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agencias.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AgenteController : ControllerBase
	{
		private readonly IAgente _IAgente;
		public AgenteController(IAgente IAge)
		{
			_IAgente = IAge;
		}

		// GETAll: api Lista agente/
		[HttpPost]
		//public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAll()
		public async Task<ActionResult<PagedResponse<List<AgenteDto>>>> PostAll([FromBody] PaginationFilter filter)
		{
			try
			{
				var Lagente = await _IAgente.PostAll(filter);
				return Ok(Lagente);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}

		//// GET api/<AgenteController>/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//	return "value";
		//}

		[HttpGet("{select}")]
		public async Task<ActionResult<IEnumerable<Agente>>> GetAllSelect()
		{
			try
			{
				var Lagente = await _IAgente.GetAllSelect();
				return Ok(Lagente);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}



		[HttpPut]
		public async Task<ActionResult<Agente>> Put(Agente agente)
		{

			try
			{
				var Elagente = await _IAgente.Update(agente);
				return Ok(Elagente);
			}
			catch (Exception e)
			{

				return NotFound("Error: " + e.Message);
			}

		}

		[HttpPost("{id}")]
		public async Task<ActionResult<Agente>> Post(Agente agente)
		{
			Agente Elagente;
			try
			{
				Elagente = await _IAgente.Create(agente);
				return Ok(Elagente);
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
				string resultado = await _IAgente.Delete(id);
				return Ok(resultado);

			}
			catch (Exception e)
			{
				return NotFound(e.Message);

			}

		}

	}
}
