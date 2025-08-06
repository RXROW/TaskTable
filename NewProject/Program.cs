using NewProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NewProject.Infrastructure.DI;
using NewProject.Application.DI;

var builder = WebApplication.CreateBuilder(args);

// Register infrastructure dependencies
builder.Services.AddInfrastructure();
// Register application dependencies
builder.Services.AddApplication();

// Register AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

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
