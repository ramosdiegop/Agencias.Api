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
		public CategoriaController(ICategoria ICate)
		{
			_ICategoria = ICate;
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


	}
}
