using Microsoft.EntityFrameworkCore;
using Product.Infrastructure;
using Products.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddServiceRegistery();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
