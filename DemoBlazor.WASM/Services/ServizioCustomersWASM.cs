using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Entities;
using DemoBlazor.Models.Interfaces;
using System.Net.Http.Json;

namespace DemoBlazor.WASM.Services;

public class ServizioCustomersWASM : ICustomers
{
    private readonly HttpClient httpClient;

    public ServizioCustomersWASM(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public async Task CreaCustomerAsync(CustomerDTO customer)
    {
        await httpClient.PostAsJsonAsync(
            "https://localhost:7251/customers", customer);
    }

    public async Task<List<CustomerDTO>?> EstraiCustomersAsync()
    {
        var responseMessage = await httpClient.GetAsync("https://localhost:7251/customers");
        if (responseMessage.IsSuccessStatusCode)
        {
            var customers = await
            responseMessage.Content
            .ReadFromJsonAsync<List<CustomerDTO>>();

            return customers;
        }
        else
        {
            throw new Exception("Servizio non raggiungibile");
        }
    }
}
