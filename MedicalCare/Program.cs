using MedicalCare.Infra;
using MedicalCare.Interfaces;
using MedicalCare.Repositoryes;
using MedicalCare.Services;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Adicione essa linha para obter a string de conexão
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MedicalCareDbContext>(options => options.UseSqlServer(connectionString));

// Configuração da Injeção de Dependência:
// Registra as implementações concretas para as interfaces utilizadas nas APP.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped <IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Certifique-se de que está dentro do escopo do builder.Services
builder.Services.AddDbContext<MedicalCareDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Transient);

// Adicione a configuração do AutoMapper
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
