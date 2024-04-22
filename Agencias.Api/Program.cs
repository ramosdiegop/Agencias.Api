using Agencias.Api.Data.Context;
using System.Globalization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Agencias.Api.Cross.Register;
using Agencias.Api.Data.Interfaz;
using Agencias.Api.Data.Mapper;
using Agencias.Api.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Services to Aplication
builder.Services.AddCors();
builder.Services.AddControllers();

//Mapping
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddAutoMapper(typeof(MappingProfile));



//Conexion DB
builder.Services.AddDbContext<DBContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySQL"), MySqlServerVersion.LatestSupportedServerVersion));


//Services Interfaz
builder.Services.AddTransient<IAgente, AgenteRepository>();
builder.Services.AddTransient<IAgencia, AgenciaRepository>();
builder.Services.AddTransient<IProvincia, ProvinciaRepository>();


//builder.Services.AddTransient<IProvincia, ProvinciaRepository>();
builder.Services.AddTransient<ILocalidad, LocalidadRepository>();
builder.Services.AddTransient<IMapping, MappingProfile>();

builder.Services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
IoCRegister.AddRegistration(builder.Services);

var app = builder.Build();


app.UseCors(option =>
{
	option.AllowAnyMethod();
	option.AllowAnyOrigin();
	option.AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
