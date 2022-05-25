namespace Vendista.Models;

public class GetCommandsResult
{
    public IEnumerable<VendistaCommand> Items { get; set; } = new List<VendistaCommand>();
}
