using Agencias.Api.Authentication;
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
	[Authenticate]
	public class AgenciaController : ControllerBase
	{
		private readonly IAgencia _IAge;
		private readonly IMapping _mapping;

		public AgenciaController(IAgencia agen, IMapping mapping)
		{
			_IAge = agen;
			_mapping = mapping;

		}

		[HttpPost]
		//public async Task<ActionResult<List<AgenciaDto>>> GetAll([FromQuery] PaginationFilter filter)
		public async Task<ActionResult<PagedResponse<List<AgenciaDto>>>> PostAll([FromBody] PaginationFilter filter)
		{
			try
			{
				var LAgencis = await _IAge.PostAll(filter);

				return Ok(LAgencis);

			}
			catch (Exception e)
			{
				return NotFound("Error:" + e.Message);
			}


		}


		[HttpGet("{id}")]
		public async Task<AgenciaDto> GetById(int id)
		{
			return await _IAge.GetById(id);
		}

		[HttpPost("{id}")]
		public async Task<ActionResult<Agencia>> Post(AgenciaDto agencia)
		{
			Agencia LaAgencia;
			var nw = _mapping.MappAgencia(agencia);

			try
			{
				LaAgencia = await _IAge.Create(nw);
				return Ok(LaAgencia);
			}
			catch (Exception e)
			{

				return NotFound("Error: " + e.Message);
			}


		}

		[HttpPut]
		public async Task<ActionResult<Agencia>> Put(AgenciaDto agencia)
		{
			Agencia LaAgencia;
			var up = _mapping.MappAgencia(agencia);
			try
			{
				LaAgencia = await _IAge.Update(up);
				return Ok(LaAgencia);
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
				string resultado = await _IAge.Delete(id);
				return Ok();

			}
			catch (Exception e)
			{
				return NotFound(e.Message);

			}

		}


	}

}
