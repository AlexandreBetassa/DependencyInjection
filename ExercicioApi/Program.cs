using ExercicioApi.Contracts.v1;
using ExercicioApi.Data.v1;
using ExercicioApi.Models.v1;
using ExercicioApi.Repositories.v1;
using ExercicioApi.Utils.v1;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
//AddMongoService();
builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddSingleton<IContractRepository, ContractRepository>();
builder.Services.AddSingleton<IInstallmentRepository, InstallmentRepository>();

builder.Services.AddSingleton<IDatabase<Contract>, Database<Contract>>();
builder.Services.AddSingleton<IDatabase<Installment>, Database<Installment>>();

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
