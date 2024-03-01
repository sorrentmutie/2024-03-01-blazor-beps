using System.Text.Json.Serialization;

namespace DemoBlazor.Models;

public class ReqResResponse
{
    public int page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public Person[]? data { get; set; }
    public Support? support { get; set; }
}

public class Support
{
    public string? url { get; set; }
    public string? text { get; set; }
}

public class Person
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }
}

