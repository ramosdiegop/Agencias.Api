using Agencias.Api.Data.Data;
using Agencias.Api.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Interfaz
{
	public interface IMapping
	{
		Agencia MappAgencia(AgenciaDto aMap);
		Categoria MappCategoria(CategoriaDto categoria);
	}
}
