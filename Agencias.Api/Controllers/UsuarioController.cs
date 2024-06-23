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
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuario _IUsuario;
		public UsuarioController(IUsuario IUsu)
		{
			_IUsuario = IUsu;
		}
		
		// GETAll: api Lista usuario/
		[HttpPost]
		public async Task<ActionResult<PagedResponse<List<Usuario>>>> PostAll([FromBody] PaginationFilter filter)
		{
			try
			{
				var Lusuario = await _IUsuario.PostAll(filter);
				return Ok(Lusuario);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}


		[HttpGet("{select}")]
		public async Task<ActionResult<IEnumerable<Usuario>>> GetAllSelect()
		{
			try
			{
				var Lusuario = await _IUsuario.GetAllSelect();
				return Ok(Lusuario);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}



		[HttpPut]
		public async Task<ActionResult<Usuario>> Put(Usuario usuario)
		{

			try
			{
				var Lusuario = await _IUsuario.Update(usuario);
				return Ok(Lusuario);
			}
			catch (Exception e)
			{

				return NotFound("Error: " + e.Message);
			}

		}

		[HttpPost("{id}")]
		public async Task<ActionResult<Usuario>> Post(Usuario usuario)
		{
			Usuario Elusuario;
			try
			{
				Elusuario = await _IUsuario.Create(usuario);
				return Ok(Elusuario);
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
				string resultado = await _IUsuario.Delete(id);
				return Ok(resultado);

			}
			catch (Exception e)
			{
				return NotFound(e.Message);

			}

		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Usuario>>> GetByUsuario([FromQuery] string usuario)
		{
			try
			{
				var Lusuario = await _IUsuario.GetByUsuario(usuario);
				return Ok(Lusuario);

			}
			catch (Exception e)
			{
				return NotFound("Error: " + e.Message);
			}

		}



	}

}
