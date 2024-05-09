using Agencias.Api.Cross.Authentication;
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
	public class SubCategoriaController : ControllerBase
	{
		private readonly ISubCategoria _ISubCategoria;
		private readonly IMapping _IMapping;

		public SubCategoriaController(ISubCategoria ICate, IMapping IMapp)
		{
			_ISubCategoria = ICate;
			_IMapping = IMapp;
		}

		[HttpPost]
		//public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAll()
		public async Task<ActionResult<PagedResponse<List<CategoriaDto>>>> PostAll([FromBody] PaginationFilter filter)
		{
			try
			{
				var LCategoria = await _ISubCategoria.PostAll(filter);
				return Ok(LCategoria);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}



	}
}
