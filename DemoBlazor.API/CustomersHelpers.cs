using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazor.API;

public static class CustomersHelpers
{
    public static async Task<IResult>
    CreateCustomer(NorthwindContext database, CustomerDTO newCustomer)
    {
        var customer = new Customer
        {
            CustomerId = newCustomer.Id,
            CompanyName = newCustomer.CompanyName,
            ContactName = newCustomer.ContactName
        };
        await database.Customers.AddAsync(customer);
        await database.SaveChangesAsync();
        return TypedResults.Created($"/customers/{customer.CustomerId}",
            customer);
    }

    public static async Task<IResult>
       GetCustomers(NorthwindContext database)
    {
        var customers = await database.Customers
        .Select(c => new CustomerDTO
        {
            Id = c.CustomerId,
            CompanyName = c.CompanyName,
            ContactName = c.ContactName
        })
        .ToListAsync();
        return Results.Ok(customers);
    }
}
