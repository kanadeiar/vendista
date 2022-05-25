namespace Vendista.Models;

public class GetCommandTypesResult
{
    public IEnumerable<CommandType> Items { get; set; } = new List<CommandType>();
}
