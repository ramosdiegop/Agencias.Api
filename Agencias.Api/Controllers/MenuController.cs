using Agencias.Api.Authentication;
using Agencias.Api.Data.Data;
using Agencias.Api.Data.Mapper;
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
	public class MenuController : ControllerBase
	{
		private readonly IMenu _IMenu;
		private readonly IMapping _mapping;
		public MenuController(IMenu Imenu,IMapping Imapp)
		{
			_IMenu = Imenu;
			_mapping = Imapp;
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



		[HttpGet("{usuario}")]
		public async Task<ActionResult<IEnumerable<MenuAccesosDto>>> GetAllSelect(int usuario)
		{
			try
			{
				if ((usuario == 0))
				{
					var Lmenu = await _IMenu.GetAllSelect(usuario);
					var i_menu = _mapping.MappMenuCrud(Lmenu);
					return Ok(i_menu);
				}
				else
				{
  				   var Lmenu = await _IMenu.GetAllSelect(usuario);
				   var i_menu = _mapping.MappMenuCrud(Lmenu);
				   return Ok(i_menu);
				}
				

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
		public async Task<ActionResult<IEnumerable<ItemDto>>> GetByUsuario([FromQuery] int idusuario)
		{
			try
			{
				var Lmenu = await _IMenu.GetByUsuario(idusuario);
				var i_menu = _mapping.MappMenu(Lmenu);
				return Ok(i_menu);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}



	}

}
