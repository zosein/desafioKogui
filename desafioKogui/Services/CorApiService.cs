using System.Diagnostics;
using System.Text.Json;
using desafioKogui.Models;


namespace desafioKogui.Services;

public class CorApiService
{
    private readonly HttpClient _client;
    private readonly string _baseUrl = "https://www.thecolorapi.com/id?hex=";

    public CorApiService()
    {
        _client = new HttpClient();
    }

    public async Task<string?> GetCorNomeAsync(string hexCode)
    {
        var limparHex = hexCode.Replace("#", "");
        var requestUrl = $"{_baseUrl}{limparHex}";

        try
        {
            HttpResponseMessage resposta = await _client.GetAsync(requestUrl);

            if (resposta.IsSuccessStatusCode)
            {
                string conteudoJson = await resposta.Content.ReadAsStringAsync();

                var corInfo = JsonSerializer.Deserialize<CorApiResponse>(conteudoJson);

                return corInfo?.Name?.Value ?? "Não encontrado";
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Erro ao chamar a API: {ex.Message}");
        }

        return hexCode; //codigo hex original retornado em caso de falha
    }
}
