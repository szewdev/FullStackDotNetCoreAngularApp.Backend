using Backend.Application.Commands.Handlers;
using Backend.Application.Commands.Interfaces;
using Backend.Application.Queries.Handlers;
using Backend.Application.Queries.Interfaces;
using Backend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductCommandHandler, ProductCommandHandler>();
builder.Services.AddScoped<IProductQueryHandler, ProductQueryHandler>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts => opts.EnableAnnotations());

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => { _ = endpoints.MapControllers(); });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();