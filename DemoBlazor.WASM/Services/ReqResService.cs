using DemoBlazor.Models;
using DemoBlazor.Models.Interfaces;
using System.Net.Http.Json;

namespace DemoBlazor.WASM.Services;

public class ReqResService : IReqResData
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private CancellationTokenSource? cancellationTokenSource;

    public ReqResService(HttpClient http, IConfiguration configuration)
    {
        this.http = http;
        this.configuration = configuration;
    }

    public void CancelRequest()
    {
        cancellationTokenSource?.Cancel();
    }

    public async Task<List<Person>?> GetPeople()
    {
        cancellationTokenSource= new CancellationTokenSource();
        var responseMessage = await http.GetAsync(configuration["ReqResUrl"],
           cancellationTokenSource.Token );

        if(responseMessage.IsSuccessStatusCode == true)
        {
            var personArray = await responseMessage
                .Content.ReadFromJsonAsync<ReqResResponse> ();
            return personArray?.data?.ToList();

        } else
        {
            return null;
        }
    }
}
