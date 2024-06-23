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
	public class MenuController : ControllerBase
	{
		private readonly IMenu _IMenu;
		public MenuController(IMenu Imenu)
		{
			_IMenu = Imenu;
		}
		
		// GETAll: api Lista usuario/
		[HttpPost]
		public async Task<ActionResult<PagedResponse<List<Menu>>>> PostAll([FromBody] PaginationFilter filter)
		{
			try
			{
				var Lmenu = await _IMenu.PostAll(filter);
				return Ok(Lmenu);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}


		[HttpGet("{select}")]
		public async Task<ActionResult<IEnumerable<Menu>>> GetAllSelect()
		{
			try
			{
				var Lmenu = await _IMenu.GetAllSelect();
				return Ok(Lmenu);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}



		[HttpPut]
		public async Task<ActionResult<Menu>> Put(Menu menu)
		{

			try
			{
				var Lmenu = await _IMenu.Update(menu);
				return Ok(Lmenu);
			}
			catch (Exception e)
			{

				return NotFound("Error: " + e.Message);
			}

		}

		[HttpPost("{id}")]
		public async Task<ActionResult<Menu>> Post(Menu menu)
		{
			Menu Elmenu;
			try
			{
				Elmenu = await _IMenu.Create(menu);
				return Ok(Elmenu);
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
				string resultado = await _IMenu.Delete(id);
				return Ok(resultado);

			}
			catch (Exception e)
			{
				return NotFound(e.Message);

			}

		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Menu>>> GetByUsuario([FromQuery] int idusuario)
		{
			try
			{
				var Lmenu = await _IMenu.GetByUsuario(idusuario);
				return Ok(Lmenu);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}



	}

}
