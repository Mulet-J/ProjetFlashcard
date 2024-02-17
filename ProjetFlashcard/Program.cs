using Infrastructure.DatabaseContext;
using Infrastructure.Persistence;
using ProjetFlashcard.Application.Interfaces;
using ProjetFlashcard.Application.Services;
using ProjetFlashcard.Domain.Entities;
using ProjetFlashcard.Domain.Repositories;
using ProjetFlashcard.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<IAppDbContext, PostgresDbContext>();

builder.Services.AddSingleton<IRepository<CardUserData>, CardUserDataRepository>();
builder.Services.AddSingleton<IRepository<Card>, CardRepository>();

builder.Services.AddSingleton<ICardUserDataService, CardUserDataService>();
builder.Services.AddSingleton<ICardService, CardService>();

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
