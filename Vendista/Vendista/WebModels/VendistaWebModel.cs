namespace Vendista.WebModels;

public class VendistaWebModel
{
    public int TerminalId { get; set; }
    public IEnumerable<CommandType> CommandTypes { get; set; }
    public int SelectedType { get; set; }
    public string Parameter1Name { get; set; }
    public int? Parameter1 { get; set; }
    public string Parameter2Name { get; set; }
    public int? Parameter2 { get; set; }
    public string Parameter3Name { get; set; }
    public int? Parameter3 { get; set; }
    public IEnumerable<VendistaCommand> VendistaCommands { get; set; }
}
