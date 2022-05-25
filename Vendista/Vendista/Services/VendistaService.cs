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
