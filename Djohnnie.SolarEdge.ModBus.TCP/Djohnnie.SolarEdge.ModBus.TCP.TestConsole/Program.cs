using Djohnnie.SolarEdge.ModBus.TCP;
using Djohnnie.SolarEdge.ModBus.TCP.Constants;
using Djohnnie.SolarEdge.ModBus.TCP.Types;
using Int16 = Djohnnie.SolarEdge.ModBus.TCP.Types.Int16;
using UInt16 = Djohnnie.SolarEdge.ModBus.TCP.Types.UInt16;
using UInt32 = Djohnnie.SolarEdge.ModBus.TCP.Types.UInt32;
using UInt64 = Djohnnie.SolarEdge.ModBus.TCP.Types.UInt64;


Console.WriteLine("Djohnnie.SolarEdge.ModBus.TCP");
Console.WriteLine();

using var client = new ModbusClient("xxx.xxx.xxx.xxx", 1502);

client.Connect();

var result1 = await client.ReadHoldingRegisters<String32>(SunspecConsts.C_Model);
Console.WriteLine(result1);

var result2 = await client.ReadHoldingRegisters<String16>(SunspecConsts.C_Version);
Console.WriteLine(result2);

var result3 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.C_DeviceAddress);
Console.WriteLine(result3);

var result4 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.C_SunSpec_DID);
Console.WriteLine(result4);

var result5 = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_DC_Voltage);
var result6 = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_DC_Voltage_SF);
Console.WriteLine($"{result5} * 10 ^ {result6} = {result5.Value * Math.Pow(10, result6.Value)}");

var result7 = await client.ReadHoldingRegisters<Acc32>(SunspecConsts.I_AC_Energy_WH);
var result8 = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_AC_Energy_WH_SF);
Console.WriteLine($"{result7} * 10 ^ {result8} = {result7.Value * Math.Pow(10, result8.Value)}");

var result9 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.I_Status_Vendor);
Console.WriteLine(result9);

var resultA = await client.ReadHoldingRegisters<String32>(SunspecConsts.Battery_1_Manufacturer_Name);
Console.WriteLine(resultA);

var resultB = await client.ReadHoldingRegisters<String32>(SunspecConsts.Battery_1_Model);
Console.WriteLine(resultB);

var resultC = await client.ReadHoldingRegisters<String32>(SunspecConsts.Battery_1_Firmware_Version);
Console.WriteLine(resultC);

var resultD = await client.ReadHoldingRegisters<String32>(SunspecConsts.Battery_1_Serial_Number);
Console.WriteLine(resultD);

var resultE = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_Rated_Energy);
Console.WriteLine(resultE);

var resultF = await client.ReadHoldingRegisters<UInt64>(SunspecConsts.Battery_1_Lifetime_Export_Energy_Counter);
Console.WriteLine(resultF);

var resultG = await client.ReadHoldingRegisters<UInt64>(SunspecConsts.Battery_1_Lifetime_Import_Energy_Counter);
Console.WriteLine(resultG);

var resultH = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_State_of_Energy);
Console.WriteLine(resultH);

var resultI = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_State_of_Health);
Console.WriteLine(resultI);

var resultJ = await client.ReadHoldingRegisters<UInt32>(SunspecConsts.Battery_2_Status);
Console.WriteLine(resultJ);

var resultK = await client.ReadHoldingRegisters<UInt32>(SunspecConsts.Battery_2_Status_Internal);
Console.WriteLine(resultK);

//await client.WriteSingleRegister(SunspecConsts.Storage_Control_Mode, 1);