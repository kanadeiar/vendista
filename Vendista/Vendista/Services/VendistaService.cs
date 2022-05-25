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
    /// <returns>Типы команд</returns>
    public async Task<IEnumerable<CommandType>> GetCommandTypes()
    {
        var token = await GetToken();
        var result = await _client.GetFromJsonAsync<GetCommandTypesResult>($"/commands/types?token={token}");
        var types = result.Items;
        return types;
    }

    /// <summary>
    /// Получение всех ранее отправленных команд
    /// </summary>
    /// <param name="terminalId">Терминал</param>
    /// <returns>Команды</returns>
    public async Task<IEnumerable<VendistaCommand>> GetCommands(int terminalId)
    {
        var token = await GetToken();
        var response = await _client.GetAsync($"/terminals/{terminalId}/commands?OrderByColumn=11&OrderDesc=true&token={token}");
        var result = JsonConvert.DeserializeObject<GetCommandsResult>(await response.Content.ReadAsStringAsync());
        var commands = result.Items;
        return commands;
    }

    /// <summary>
    /// Отправка команды на терминал
    /// </summary>
    /// <param name="terminalId">Терминал</param>
    /// <param name="commandId">Команда</param>
    /// <param name="parameter1"></param>
    /// <param name="paremeter2"></param>
    /// <param name="paremeter3"></param>
    public async Task SendVendistaCommand(int terminalId, int commandId, int? parameter1, int? paremeter2, int? paremeter3)
    {
        var token = await GetToken();
        var model = new SendVendistaCommand
        {
            Command_Id = commandId,
            Parameter1 = parameter1 ?? 0,
            Parameter2 = paremeter2 ?? 0,
            Parameter3 = paremeter3 ?? 0,
        };
        var response = await _client.PostAsJsonAsync($"/terminals/{terminalId}/commands?token={token}", model);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Получение токена доступа к Вендисте
    /// </summary>
    /// <returns>Токен</returns>
    public async Task<string> GetToken()
    {
        var result = await _client.GetFromJsonAsync<TokenData>("/token?login=part&password=part");
        return result.Token;
    }
}
