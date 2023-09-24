using ModularMonolith.Framework.Extensions;
using ModularMonolith.Modules.Companies.Configuration;
using ModularMonolith.Modules.Visits.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFramework();
builder.Services.AddCompanyModule(builder.Configuration.GetConnectionString("CompanyDb"));
builder.Services.AddVisitModule(builder.Configuration.GetConnectionString("VisitDb"));

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