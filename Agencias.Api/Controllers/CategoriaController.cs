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
	public class CategoriaController : ControllerBase
	{
		private readonly ICategoria _ICategoria;
		private readonly IMapping _IMapping;
		
		public CategoriaController(ICategoria ICate, IMapping IMapp)
		{
			_ICategoria = ICate;
			_IMapping = IMapp;
		}

		[HttpPost]
		//public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAll()
		public async Task<ActionResult<PagedResponse<List<CategoriaDto>>>> PostAll([FromBody] PaginationFilter filter)
		{
			try
			{
				var LCategoria = await _ICategoria.PostAll(filter);
				return Ok(LCategoria);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}

		[HttpPost("{id}")]
		public async Task<ActionResult<Categoria>> Post(CategoriaDto categoria)
		{
			Categoria LaCategoria;
			var nw = _IMapping.MappCategoria(categoria);

			try
			{
				LaCategoria = await _ICategoria.Create(nw);
				return Ok(LaCategoria);
			}
			catch (Exception e)
			{

				return NotFound("Error: " + e.Message);
			}
		}

		[HttpPut]
		public async Task<ActionResult<Categoria>> Put(CategoriaDto categoria)
		{
			Categoria Lacategoria;
			var up = _IMapping.MappCategoria(categoria);
			try
			{
				Lacategoria = await _ICategoria.Update(up);
				return Ok(Lacategoria);
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
				string resultado = await _ICategoria.Delete(id);
				return Ok();

			}
			catch (Exception e)
			{
				return NotFound(e.Message);

			}

		}


	}
}
