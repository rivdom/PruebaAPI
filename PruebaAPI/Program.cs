using Microsoft.EntityFrameworkCore;
using PruebaAPI.Automapper;
using PruebaAPI.Data;
using PruebaAPI.Repositories;
using PruebaAPI.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
//configBD:
builder.Services.AddDbContext<ApplicationDBContext>(opt =>
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));
//servicio TrabajadorRepository
builder.Services.AddScoped<ITrabajadorRepository, TrabajadorRepository>();
//Automapper
builder.Services.AddAutoMapper(typeof(TrabajadorMapper));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
