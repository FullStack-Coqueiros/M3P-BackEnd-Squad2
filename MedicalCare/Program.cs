using MedicalCare.Infra;
using MedicalCare.Interfaces;
using MedicalCare.Repositoryes;
using MedicalCare.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicione essa linha para obter a string de conexão
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MedicalCareDbContext>(options => options.UseSqlServer(connectionString));

// Configuração da Injeção de Dependência:
// Registra as implementações concretas para as interfaces(Services) utilizadas nas APP.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IExameService, ExameService>();
builder.Services.AddScoped<IDietaService, DietaService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddScoped<ILogService, LogService>();






// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth", Version = "v1" });
    //Adição do header de autenticação no Swagger 
    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                                              Escreva 'Bearer' [espaço] e o token gerado no login na caixa abaixo.
                                              Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                                          {
                                            {
                                              new OpenApiSecurityScheme
                                              {
                                                Reference = new OpenApiReference
                                                  {
                                                    Type = ReferenceType.SecurityScheme,
                                                    Id = JwtBearerDefaults.AuthenticationScheme
                                                  },
                                                },
                                                new List<string>()
                                              }
                                            });
});

var jwtChave = builder.Configuration.GetSection("jwtTokenChave").Get<string>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtChave)),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true

    };
});

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
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "auth v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
