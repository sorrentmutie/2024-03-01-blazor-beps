using DemoBlazor.Models.Entities;
using Microsoft.EntityFrameworkCore;
using DemoBlazor.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<NorthwindContext>(opzioni =>
{
    opzioni.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
   .AllowAnyOrigin()
   .AllowAnyHeader()
   .AllowAnyMethod());


var categoriesGroup = app.MapGroup("/categories");
categoriesGroup.MapGet("/", CategoriesHelpers.GetCategories);
categoriesGroup.MapGet("/{id}", CategoriesHelpers.GetById);
categoriesGroup.MapPost("/", CategoriesHelpers.CreateCategory);
categoriesGroup.MapDelete("/{id}", CategoriesHelpers.DeleteCategory);
categoriesGroup.MapPut("/{id}", CategoriesHelpers.UpdateCategory);
categoriesGroup.MapPatch("/{id}", CategoriesHelpers.PatchCategory);

var customersGroup = app.MapGroup("/customers");
customersGroup.MapPost("/", CustomersHelpers.CreateCustomer);
customersGroup.MapGet("/", CustomersHelpers.GetCustomers);


app.Run();

