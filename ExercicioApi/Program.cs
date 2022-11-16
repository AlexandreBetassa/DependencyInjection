using ExercicioApi.Contracts.v1;
using ExercicioApi.Data.v1;
using ExercicioApi.Models.v1;
using ExercicioApi.Repositories.v1;
using ExercicioApi.Utils.v1;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Drawing.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddMongoService();

builder.Services.AddScoped<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IDatabase<IEntity>, Database<IEntity>>();
builder.Services.AddMongoService();

//COMO FARIA NORMALMENTE***********************************
//public IService AddMongoService()
//{
//    DatabaseSettings _settings = new();
//    var contracts = new MongoClient(_settings.ConnectionString);
//    var database = contracts.GetDatabase(_settings.DatabaseName);
//    IMongoCollection<Contract> collection = database.GetCollection<Contract>(_settings.ContractCollectionName);
//}
//COMO FARIA NORMALMENTE***********************************



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
