using ExercicioApi.Contracts.v1;
using ExercicioApi.Repositories.v1;
using ExercicioApi.Serivce.v11;
using ExercicioApi.Utils.v1;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
builder.Services.AddMongoDb();

builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IMongoClient), typeof(MongoClient));

//=====================

//builder.Services.AddSingleton<IMongoClient>(c =>
//{
//    return new MongoClient(
//        string.Format("mongodb://localhost:27017"));
//});

//builder.Services.AddScoped(c => c.GetService<IMongoClient>().StartSession());

//==============
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
