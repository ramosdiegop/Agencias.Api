using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencias.Api.Data.Data
{
	[Table("productor")]
	public class Productor
	{
		[Key]
		public int Id { get; set; }
		public string? Nombre { get; set; }
		[ForeignKey("Localidad")]
		public int? Idlocalidad { get; set; }
		[ForeignKey("Tipodocumento")]
		public int? Idtipodocu { get; set; }
		public int? Nrodocu { get; set; }
		[ForeignKey("Agencia")]
		public int? Idagencia { get; set; }
		[Column("producto")]
		public int? CodigoProductor { get; set; }
		public string? Domicilio { get; set; }
		public DateOnly Fec_Nacimiento { get; set; }
		public string? Essupervisor { get; set; }
		public DateTime inicio { get; set; }
		[ForeignKey("Estadoproductor")]
		public int? Idestado { get; set; }
		[ForeignKey("Categoria")]
		public int? Idcategoria { get; set; }
		public string? Legajo { get; set; }
		public int? Comisionxcatego { get; set; }
		public string? Cuit { get; set; }
		[ForeignKey("Genero")]
		public int? Idgenero { get; set; }
		public DateTime Fecha_Carga { get; set; }
		public DateTime Fecha_Baja { get; set; }
		public DateTime Fecha_Modificacion { get; set; }
		public string? Inscripto { get; set; }


		public virtual Localidad? Localidad { get; set; }
		public virtual TipoDocumento? Tipodocumento { get; set; }
		public virtual Agencia? Agencia { get; set; }
		public virtual EstadoProductor? Estadoproductor { get; set; }
		public virtual Categoria? Categoria { get; set; }
		public virtual Genero? Genero { get; set; }


	}
}
