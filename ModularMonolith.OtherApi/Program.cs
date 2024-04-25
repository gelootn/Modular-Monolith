

using ModularMonolith.Framework.Configuration;
using ModularMonolith.Modules.Companies.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFramework();
builder.Services.AddCompanyModule(builder.Configuration.GetConnectionString("CompanyDb"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Serilog
builder.Services.AddSerilog(cfg =>
{
    cfg.ReadFrom.Configuration(builder.Configuration);
    
});
builder.Host.UseSerilog();



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

