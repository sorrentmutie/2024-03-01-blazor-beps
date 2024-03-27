using DemoBlazor.Models.DTO;

namespace DemoBlazor.Models.Interfaces;

public interface ICustomers
{
    Task<List<CustomerDTO>?> EstraiCustomersAsync();
    Task CreaCustomerAsync(CustomerDTO customer);
}
