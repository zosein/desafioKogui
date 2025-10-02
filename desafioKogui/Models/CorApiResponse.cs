using System.Text.Json.Serialization;

namespace desafioKogui.Models;

//classe mapeia a resposta JSON enviada da api de cores  
public class CorApiResponse
{
    [JsonPropertyName("name")]
    public CorNome? Name { get; set; }
}

public class CorNome
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
