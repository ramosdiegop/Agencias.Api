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
	public class PlanController : ControllerBase
	{
		private readonly IPlan _IPlan;
		public PlanController(IPlan IPlan)
		{
			_IPlan = IPlan;
		}

		// GETAll: api Lista agente/
		[HttpPost]
		//public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAll()
		public async Task<ActionResult<PagedResponse<List<Plan>>>> PostAll([FromBody] PaginationFilter filter)
		{
			try
			{
				var Elplan = await _IPlan.PostAll(filter);
				return Ok(Elplan);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}


		[HttpGet("{select}")]
		public async Task<ActionResult<IEnumerable<Plan>>> GetAllSelect()
		{
			try
			{
				var Elplan = await _IPlan.GetAllSelect();
				return Ok(Elplan);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}



		[HttpPut]
		public async Task<ActionResult<Plan>> Put(Plan plan)
		{

			try
			{
				var Elplan = await _IPlan.Update(plan);
				return Ok(Elplan);
			}
			catch (Exception e)
			{

				return NotFound("Error: " + e.Message);
			}

		}

		[HttpPost("{id}")]
		public async Task<ActionResult<Plan>> Post(Plan plan)
		{
			Plan Elplan;
			try
			{
				Elplan = await _IPlan.Create(plan);
				return Ok(Elplan);
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
				string resultado = await _IPlan.Delete(id);
				return Ok(resultado);

			}
			catch (Exception e)
			{
				return NotFound(e.Message);

			}

		}

	}
}
