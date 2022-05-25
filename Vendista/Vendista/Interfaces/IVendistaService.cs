namespace Vendista.Interfaces;

public interface IVendistaService
{
    public Task<string> GetToken();
    public Task<IEnumerable<CommandType>> GetCommandTypes();
}
