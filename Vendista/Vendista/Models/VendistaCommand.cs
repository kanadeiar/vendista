namespace Vendista.Models;

public class VendistaCommand
{
    public DateTime Time_Created { get; set; }
    public int Command_Id { get; set; }
    public string CommandName { get; set; }
    public int Parameter1 { get; set; }
    public int Parameter2 { get; set; }
    public int Parameter3 { get; set; }
    public string State_Name { get; set; }
}
