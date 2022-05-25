namespace Vendista.Interfaces;

public interface IVendistaService
{
    Task<IEnumerable<CommandType>> GetCommandTypes();
    Task<IEnumerable<VendistaCommand>> GetCommands(int terminalId);
    Task SendVendistaCommand(int terminalId, int commandId, int? parameter1, int? paremeter2, int? paremeter3);
    Task<string> GetToken();
}
