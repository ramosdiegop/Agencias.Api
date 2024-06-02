using Agencias.Api.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Context
{
	public partial class DBContext : DbContext
	{
		public DBContext()
		{
		}

		public DBContext(DbContextOptions<DBContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Agencia> Agencia { get; set; } = null!;
		public virtual DbSet<Agente> Agente { get; set; } = null!;
		public virtual DbSet<Localidad> Localidad { get; set; } = null!;
		public virtual DbSet<Provincia> Provincia { get; set; } = null!;
		public virtual DbSet<Categoria> Categoria { get; set; } = null!;
		public virtual DbSet<SubCategoria> SubCategoria { get; set; } = null!;
		public virtual DbSet<Plan> Plan { get; set; } = null!;
		public virtual DbSet<Productor> Productor { get; set; } = null!;
		public virtual DbSet<Genero> Genero { get; set; } = null!;
		public virtual DbSet<TipoDocumento> TipoDocumento { get; set; } = null!;
		public virtual DbSet<EstadoProductor> EstadoProductor { get; set; } = null!;	


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("utf8_general_ci")
				.HasCharSet("utf8");
			
			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
