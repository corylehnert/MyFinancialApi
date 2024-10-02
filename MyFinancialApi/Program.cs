using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Domain.Providers;
using System.Data.Common;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DbConnection, SqlConnection>();
builder.Services.AddTransient<IAddDebtProvider, AddDebtProvider>();
builder.Services.AddTransient<IAddDebtManager, AddDebtManager>();
builder.Services.AddTransient<IFinancialReportProvider, FinancialReportProvider>();
builder.Services.AddTransient<IFinancialReportManager, FinancialReportManager>();

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
