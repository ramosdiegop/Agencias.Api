using Agencias.Api.Data.Interfaz;
using Agencias.Api.Data.Mapper;
using Agencias.Api.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Cross.Register
{
	public static class IoCRegister
	{

		public static IServiceCollection AddRegistration(this IServiceCollection services)
		{
			AddRegisterRepositories(services);
			AddRegisterServices(services);

			return services;
		}

		private static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
		{
			//Services Interfaz Repository
			services.AddTransient<IAgente, AgenteRepository>();
			services.AddTransient<IAgencia, AgenciaRepository>();
			services.AddTransient<IProvincia, ProvinciaRepository>();
			services.AddTransient<ILocalidad, LocalidadRepository>();
			services.AddTransient<IMapping, MappingProfile>();
			services.AddTransient<ICategoria, CategoriaRepository>();
			services.AddTransient<ISubCategoria, SubCategoriaRepository>();




			return services;
		}

		private static IServiceCollection AddRegisterServices(this IServiceCollection services)
		{


			return services;
		}

	}
}
