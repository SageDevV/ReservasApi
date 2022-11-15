using Application.Interfaces;
using Application.Services;
using Data;
using Data.Interfaces;
using Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
ConfigureServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient(typeof(IDapperConfig<>), typeof(DapperConfig<>));
    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();
    builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();

    builder.Services.AddScoped<ISalaRepository, SalaRepository>();
    builder.Services.AddScoped<IReservaApplication, ReservaApplication>();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
