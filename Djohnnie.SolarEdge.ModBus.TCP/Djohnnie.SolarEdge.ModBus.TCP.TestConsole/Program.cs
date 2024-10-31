using Djohnnie.SolarEdge.ModBus.TCP;
using Djohnnie.SolarEdge.ModBus.TCP.Constants;
using Djohnnie.SolarEdge.ModBus.TCP.Types;
using Int16 = Djohnnie.SolarEdge.ModBus.TCP.Types.Int16;
using Int32 = Djohnnie.SolarEdge.ModBus.TCP.Types.Int32;
using UInt16 = Djohnnie.SolarEdge.ModBus.TCP.Types.UInt16;
using UInt32 = Djohnnie.SolarEdge.ModBus.TCP.Types.UInt32;
using UInt64 = Djohnnie.SolarEdge.ModBus.TCP.Types.UInt64;


Console.WriteLine("Djohnnie.SolarEdge.ModBus.TCP");
Console.WriteLine();

using var client = new ModbusClient("x.x.x.x", 1);

await client.Connect();

//Storage_Control_Mode: 1
//Storage_AC_Charge_Policy: 1
//Storage_AC_Charge_Limit: 0
//Storage_Backup_Reserved_Setting: 0
//Storage_Charge_Discharge_Default_Mode: 0
//Remote_Control_Command_Timeout: 3600
//Remote_Control_Command_Mode: 65535
//Remote_Control_Charge_Limit: 5000 (16384, 17820)
//Remote_Control_Command_Discharge_Limit: 5000

//await client.WriteSingleRegister(SunspecConsts.Storage_Control_Mode, (ushort)1);

var resultA = await client.ReadHoldingRegisters<Int32>(SunspecConsts.AdvancedPwrControlEn);
Console.WriteLine($"AdvancedPwrControlEn: {resultA}");

var resultB = await client.ReadHoldingRegisters<Int32>(SunspecConsts.ReactivePwrConfig);
Console.WriteLine($"ReactivePwrConfig: {resultB}");

var result1 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Storage_Control_Mode);
Console.WriteLine($"Storage_Control_Mode: {result1}");

var result2 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Storage_AC_Charge_Policy);
Console.WriteLine($"Storage_AC_Charge_Policy: {result2}");

var result3 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Storage_AC_Charge_Limit);
Console.WriteLine($"Storage_AC_Charge_Limit: {result3}");

var result4 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Storage_Backup_Reserved_Setting);
Console.WriteLine($"Storage_Backup_Reserved_Setting: {result4}");

var result5 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Storage_Charge_Discharge_Default_Mode);
Console.WriteLine($"Storage_Charge_Discharge_Default_Mode: {result5}");

//await client.WriteSingleRegister(SunspecConsts.Remote_Control_Command_Timeout, (uint)7200);
var result6 = await client.ReadHoldingRegisters<UInt32>(SunspecConsts.Remote_Control_Command_Timeout);
Console.WriteLine($"Remote_Control_Command_Timeout: {result6}");

await client.WriteSingleRegister(SunspecConsts.Remote_Control_Command_Mode, (ushort)3);
var result7 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Remote_Control_Command_Mode);
Console.WriteLine($"Remote_Control_Command_Mode: {result7}");

//await client.WriteSingleRegister(SunspecConsts.Remote_Control_Charge_Limit, 1500f);
var result8 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Remote_Control_Charge_Limit);
Console.WriteLine($"Remote_Control_Charge_Limit: {result8}");


var result9 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Remote_Control_Command_Discharge_Limit);
Console.WriteLine($"Remote_Control_Command_Discharge_Limit: {result9}");


//while (true)
//{
//    await Task.Delay(10000);

//    Console.WriteLine();
//    Console.WriteLine("-----------");
//    Console.WriteLine();

//    result1 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Storage_Control_Mode);
//    Console.WriteLine($"Storage_Control_Mode: {result1}");

//    result2 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Storage_AC_Charge_Policy);
//    Console.WriteLine($"Storage_AC_Charge_Policy: {result2}");

//    result3 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Storage_AC_Charge_Limit);
//    Console.WriteLine($"Storage_AC_Charge_Limit: {result3}");

//    result4 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Storage_Backup_Reserved_Setting);
//    Console.WriteLine($"Storage_Backup_Reserved_Setting: {result4}");

//    result5 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Storage_Charge_Discharge_Default_Mode);
//    Console.WriteLine($"Storage_Charge_Discharge_Default_Mode: {result5}");

//    result6 = await client.ReadHoldingRegisters<UInt32>(SunspecConsts.Remote_Control_Command_Timeout);
//    Console.WriteLine($"Remote_Control_Command_Timeout: {result6}");

//    result7 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Remote_Control_Command_Mode);
//    Console.WriteLine($"Remote_Control_Command_Mode: {result7}");

//    if (result7.Value == 7)
//    {
//        await client.WriteSingleRegister(SunspecConsts.Storage_Control_Mode, (ushort)1);
//    }

//    result8 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Remote_Control_Charge_Limit);
//    Console.WriteLine($"Remote_Control_Charge_Limit: {result8}");

//    result9 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Remote_Control_Command_Discharge_Limit);
//    Console.WriteLine($"Remote_Control_Command_Discharge_Limit: {result9}");
//}

//var result1 = await client.ReadHoldingRegisters<String32>(SunspecConsts.C_Model);
//Console.WriteLine(result1);

//client.Disconnect();
//await client.Connect();

//var result2 = await client.ReadHoldingRegisters<String16>(SunspecConsts.C_Version);
//Console.WriteLine(result2);

//var result3 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.C_DeviceAddress);
//Console.WriteLine(result3);

//var result4 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.C_SunSpec_DID);
//Console.WriteLine(result4);

//var result5 = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_DC_Voltage);
//var result6 = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_DC_Voltage_SF);
//Console.WriteLine($"{result5} * 10 ^ {result6} = {result5.Value * Math.Pow(10, result6.Value)}");

//var result7 = await client.ReadHoldingRegisters<Acc32>(SunspecConsts.I_AC_Energy_WH);
//var result8 = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_AC_Energy_WH_SF);
//Console.WriteLine($"{result7} * 10 ^ {result8} = {result7.Value * Math.Pow(10, result8.Value)}");

//var result9 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.I_Status_Vendor);
//Console.WriteLine(result9);

//var resultA = await client.ReadHoldingRegisters<String32>(SunspecConsts.Battery_1_Manufacturer_Name);
//Console.WriteLine(resultA);

//var resultB = await client.ReadHoldingRegisters<String32>(SunspecConsts.Battery_1_Model);
//Console.WriteLine(resultB);

//var resultC = await client.ReadHoldingRegisters<String32>(SunspecConsts.Battery_1_Firmware_Version);
//Console.WriteLine(resultC);

//var resultD = await client.ReadHoldingRegisters<String32>(SunspecConsts.Battery_1_Serial_Number);
//Console.WriteLine(resultD);

//var resultE = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_Rated_Energy);
//Console.WriteLine(resultE);

//var resultF = await client.ReadHoldingRegisters<UInt64>(SunspecConsts.Battery_1_Lifetime_Export_Energy_Counter);
//Console.WriteLine(resultF);

//var resultG = await client.ReadHoldingRegisters<UInt64>(SunspecConsts.Battery_1_Lifetime_Import_Energy_Counter);
//Console.WriteLine(resultG);

//var resultH = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_State_of_Energy);
//Console.WriteLine(resultH);

//var resultI = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_State_of_Health);
//Console.WriteLine(resultI);

//var resultJ = await client.ReadHoldingRegisters<UInt32>(SunspecConsts.Battery_2_Status);
//Console.WriteLine(resultJ);

//var resultK = await client.ReadHoldingRegisters<UInt32>(SunspecConsts.Battery_2_Status_Internal);
//Console.WriteLine(resultK);

//await client.WriteSingleRegister(SunspecConsts.Storage_Control_Mode, 1);