namespace Vendista.WebModels;

public class VendistaWebModel
{
    public int TerminalId { get; set; }
    public IEnumerable<CommandType> CommandTypes { get; set; }
    public int SelectedType { get; set; }
    public int Parameter1 { get; set; }
    public int Parameter2 { get; set; }
    public int Parameter3 { get; set; }
}
