using Newtonsoft.Json;
using System.Net.Http.Json;
using Vendista.Models;

namespace Vendista.Services;

public class VendistaService : IVendistaService
{
    private readonly HttpClient _client;
    public VendistaService(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Получение всех типов команд
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CommandType>> GetCommandTypes()
    {
        var token = await GetToken();
        var result = await _client.GetFromJsonAsync<GetCommandTypesResult>($"/commands/types?token={token}");
        var types = result.Items;
        return types;
    }

    public async Task<IEnumerable<VendistaCommand>> GetCommands(int terminalId)
    {
        var token = await GetToken();
        var response = await _client.GetAsync($"/terminals/{terminalId}/commands?token={token}");
        var result = JsonConvert.DeserializeObject<GetCommandsResult>(await response.Content.ReadAsStringAsync());
        var commands = result.Items;
        return commands;
    }

    /// <summary>
    /// Получение токена доступа к Вендисте
    /// </summary>
    /// <returns></returns>
    public async Task<string> GetToken()
    {
        var result = await _client.GetFromJsonAsync<TokenData>("/token?login=part&password=part");
        return result.Token;
    }
}
