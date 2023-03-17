global using WebAPI.Models;
global using WebAPI.Services;
global using WebAPI.Dtos.Character;
global using WebAPI.Dtos.KhoaDto;
global using WebAPI.Dtos.GiangVienDto;
global using WebAPI.Dtos.LopDto;
global using AutoMapper;
global using WebAPI.Data;
global using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IKhoaService, KhoaService>();
builder.Services.AddScoped<IGiangVienService, GiangVienService>();
builder.Services.AddScoped<ILopService, LopService>();

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
