namespace Vendista.Interfaces;

public interface IVendistaService
{
    public Task<IEnumerable<CommandType>> GetCommandTypes();
    public Task<IEnumerable<VendistaCommand>> GetCommands(int terminalId);
    public Task<string> GetToken();
}
