using Djohnnie.SolarEdge.ModBus.TCP.Constants;
using Djohnnie.SolarEdge.ModBus.TCP.Converters;
using Djohnnie.SolarEdge.ModBus.TCP.Exceptions;
using Djohnnie.SolarEdge.ModBus.TCP.Types;
using NModbus;
using System.Net.Sockets;

namespace Djohnnie.SolarEdge.ModBus.TCP;

public interface IModbusClient : IDisposable
{
    public Task Connect();
    public void Disconnect();
}

public class ModbusClient : IModbusClient
{
    private const byte UNIT_IDENTIFIER = 1;

    private TcpClient _client;
    private IModbusMaster _master;

    public string IpAddress { get; init; }
    public int Port { get; init; }
    public int ConnectionTimeout { get; init; }
    public bool IsConnected => _client == null ? false : _client.Connected;

    public ModbusClient(string ipAddress, int port, int connectionTimeout = 10000)
    {
        IpAddress = ipAddress;
        Port = port;
        ConnectionTimeout = connectionTimeout;
    }

    public async Task Connect()
    {
        if (!IsConnected)
        {
            _client = new TcpClient()
            {
                ReceiveTimeout = ConnectionTimeout,
                SendTimeout = ConnectionTimeout,
            };
            await _client.ConnectAsync(IpAddress, Port);
            var factory = new ModbusFactory();
            _master = factory.CreateMaster(_client);
        }
    }

    public void Disconnect()
    {
        _master.Dispose();
        _client.Dispose();
    }

    public async Task<TResult> ReadHoldingRegisters<TResult>(ushort address) where TResult : ModbusType, new()
    {
        if (!IsConnected)
        {
            throw new ModbusClientNotConnectedException();
        }

        var sunspecDefinition = SunspecConsts.SunspecDefinitions[address];

        var result = new TResult()
        {
            Address = address,
            Name = sunspecDefinition.Name,
            Description = sunspecDefinition.Description
        };

        var data = await _master.ReadHoldingRegistersAsync(UNIT_IDENTIFIER, address, result.Size);
        result.SetValue(data);

        return result;
    }

    public async Task WriteSingleRegister(ushort address, ushort value)
    {
        if (!IsConnected)
        {
            throw new ModbusClientNotConnectedException();
        }

        await _master.WriteSingleRegisterAsync(UNIT_IDENTIFIER, address, value);
    }

    public async Task WriteSingleRegister(ushort address, uint value)
    {
        if (!IsConnected)
        {
            throw new ModbusClientNotConnectedException();
        }

        var bytes = BitConverter.GetBytes(value);
        var data = new ushort[2] { BitConverter.ToUInt16(bytes, 0), BitConverter.ToUInt16(bytes, 2) };
        await _master.WriteMultipleRegistersAsync(UNIT_IDENTIFIER, address, data);
    }

    public async Task WriteSingleRegister(ushort address, float value)
    {
        if (!IsConnected)
        {
            throw new ModbusClientNotConnectedException();
        }

        var bytes = BitConverter.GetBytes(value);
        var data = new ushort[2] { BitConverter.ToUInt16(bytes, 0), BitConverter.ToUInt16(bytes, 2) };
        await _master.WriteMultipleRegistersAsync(UNIT_IDENTIFIER, address, data);
    }

    public void Dispose()
    {
        Disconnect();
    }
}