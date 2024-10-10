namespace Djohnnie.SolarEdge.ModBus.TCP.Types;

public class ModbusType
{
    public string Name { get; init; }
    public int Address { get; init; }
    public virtual ushort Size { get; }
    public string Description { get; init; }
}