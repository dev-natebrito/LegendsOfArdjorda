using LegendsOfArdjorda.Models;
using LegendsOfArdjorda.Models.DBsettings;
using LegendsOfArdjorda.Services;
using LegendsOfArdjorda.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<LoaDatabaseSettings>(
    builder.Configuration.GetSection(nameof(LoaDatabaseSettings)));

builder.Services.AddSingleton<ILoaDatabaseSettings>(
    loa => loa.GetRequiredService<IOptions<LoaDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(m =>
    new MongoClient(builder.Configuration.GetValue<string>("LoaDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ICharacterService, CharacterService>();

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