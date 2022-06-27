using Microsoft.EntityFrameworkCore;
using XML.Domain;
using Microsoft.Extensions.DependencyInjection;
using XML.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<XMLContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("XMLContext") ?? throw new InvalidOperationException("Connection string 'XMLContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString(("XMLContext"))));

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
