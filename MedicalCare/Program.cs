using MedicalCare.Infra;
using MedicalCare.Interfaces;
using MedicalCare.Repositoryes;
using MedicalCare.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adicione essa linha para obter a string de conex�o
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MedicalCareDbContext>(options => options.UseSqlServer(connectionString));

// Configura��o da Inje��o de Depend�ncia:
// Registra as implementa��es concretas para as interfaces(Services) utilizadas nas APP.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped <IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IExameService, ExameService>();
builder.Services.AddScoped<IDietaService, DietaService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddScoped<ILogService, LogService>();




// Configura��o da serializa��o JSON para enums
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
//    });


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Certifique-se de que est� dentro do escopo do builder.Services
builder.Services.AddDbContext<MedicalCareDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Transient);

// Adicione a configura��o do AutoMapper
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

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
