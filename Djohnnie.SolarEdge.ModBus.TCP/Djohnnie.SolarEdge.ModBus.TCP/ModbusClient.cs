using Djohnnie.SolarEdge.ModBus.TCP.Constants;
using Djohnnie.SolarEdge.ModBus.TCP.Converters;
using Djohnnie.SolarEdge.ModBus.TCP.Types;
using NModbus;
using System.Net.Sockets;

namespace Djohnnie.SolarEdge.ModBus.TCP;

public interface IModbusClient : IDisposable
{
    public void Connect();
    public void Disconnect();
}

public class ModbusClient : IModbusClient
{
    private const byte UNIT_IDENTIFIER = 1;

    private readonly TcpClient _client;

    public string IpAddress { get; init; }
    public int Port { get; init; }
    public int ConnectionTimeout { get; init; }

    public ModbusClient(string ipAddress, int port, int connectionTimeout = 5000)
    {
        IpAddress = ipAddress;
        Port = port;
        ConnectionTimeout = connectionTimeout;

        _client = new TcpClient(IpAddress, Port)
        {
            ReceiveTimeout = ConnectionTimeout,
            SendTimeout = ConnectionTimeout
        };
    }

    public void Connect()
    {
        //_client.Connect(new IPEndPoint(IPAddress.Parse(IpAddress), Port), ModbusEndianness.LittleEndian);
    }

    public void Disconnect()
    {
        //_client.Disconnect();
    }

    public async Task<TResult> ReadHoldingRegisters<TResult>(ushort address) where TResult : ModbusType, new()
    {
        var sunspecDefinition = SunspecConsts.SunspecDefinitions[address];

        var result = new TResult()
        {
            Address = address,
            Name = sunspecDefinition.Name,
            Description = sunspecDefinition.Description
        };

        var factory = new ModbusFactory();
        var master = factory.CreateMaster(_client);
        var data = await master.ReadHoldingRegistersAsync(UNIT_IDENTIFIER, address, result.Size);
        result.SetValue(data);

        return result;
    }

    public async Task WriteSingleRegister(ushort address, ushort value)
    {
        var factory = new ModbusFactory();
        var master = factory.CreateMaster(_client);

        await master.WriteSingleRegisterAsync(UNIT_IDENTIFIER, address, value);
    }

    public void Dispose()
    {
        if (_client != null)
        {
            _client.Dispose();
        }
    }
}