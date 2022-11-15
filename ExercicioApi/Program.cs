using ExercicioApi.Contracts.v1;
using ExercicioApi.Models.v1;
using ExercicioApi.Repositories.v1;
using ExercicioApi.Utils.v1;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddScoped<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
builder.Services.AddScoped<IContractRepository, ContractRepository>();


//COMO FARIA NORMALMENTE***********************************
//DatabaseSettings _settings = new();
//var contracts = new MongoClient(_settings.ConnectionString);
//var database = contracts.GetDatabase(_settings.DatabaseName);
//IMongoCollection<Contract> collection = database.GetCollection<Contract>(_settings.ContractCollectionName);
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
