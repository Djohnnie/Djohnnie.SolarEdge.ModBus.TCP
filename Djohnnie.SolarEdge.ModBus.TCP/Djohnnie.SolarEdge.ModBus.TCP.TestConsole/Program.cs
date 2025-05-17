using Djohnnie.SolarEdge.ModBus.TCP;
using Djohnnie.SolarEdge.ModBus.TCP.Constants;
using Djohnnie.SolarEdge.ModBus.TCP.Types;
using Int16 = Djohnnie.SolarEdge.ModBus.TCP.Types.Int16;
using UInt16 = Djohnnie.SolarEdge.ModBus.TCP.Types.UInt16;
using UInt32 = Djohnnie.SolarEdge.ModBus.TCP.Types.UInt32;
using UInt64 = Djohnnie.SolarEdge.ModBus.TCP.Types.UInt64;


Console.WriteLine("Djohnnie.SolarEdge.ModBus.TCP");
Console.WriteLine();

using var client = new ModbusClient("192.168.10.201", 1502);

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

//await client.WriteSingleRegister(SunspecConsts.ExportControlMode, 0);
//await client.WriteSingleRegister(SunspecConsts.ExportControlSiteLimit, 0f);

//while (true)
//{
//    // https://github.com/WillCodeForCats/solaredge-modbus-multi/wiki/Template-Sensors-for-Power-and-Energy
//    var resultA = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_AC_Power);
//    var resultB = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_AC_Power_SF);
//    var resultC = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_DC_Power);
//    var resultD = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_DC_Power_SF);
//    var resultE = await client.ReadHoldingRegisters<Int16>(SunspecConsts.M1_AC_Power);
//    var resultF = await client.ReadHoldingRegisters<Int16>(SunspecConsts.M1_AC_Power_SF);
//    var resultG = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_Instantaneous_Power);
//    var resultX = await client.ReadHoldingRegisters<Acc32>(SunspecConsts.I_AC_Energy_WH);
//    var resultY = await client.ReadHoldingRegisters<Int16>(SunspecConsts.I_AC_Energy_WH_SF);
//    Console.Clear();

//    var batteryPower = Math.Round(resultG.Value / 1000f, 2);
//    var solarPower = Math.Round(resultC.Value * Math.Pow(10, resultD.Value) / 1000.0, 2) + batteryPower;
//    var gridImport = Math.Round(resultE.Value * Math.Pow(10, resultF.Value) / 1000.0, 2);
//    var powerConsumption = Math.Round(resultA.Value * Math.Pow(10, resultB.Value) / 1000.0, 2) - gridImport;


//    Console.WriteLine($"Battery power: {batteryPower}");
//    Console.WriteLine($"Solar power: {solarPower}");
//    Console.WriteLine($"Grid import: {gridImport}");
//    Console.WriteLine($"Power consumption: {powerConsumption}");

//    Console.WriteLine();
//    //Console.WriteLine($"{Math.Round(resultX.Value * Math.Pow(10, (double)resultY.Value)) / 1_000_000f}");

//    await Task.Delay(1000);
//}
var resultA = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.ExportControlMode);
Console.WriteLine($"ExportControlMode: {resultA}");

var resultB = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.ExportControlLimitMode);
Console.WriteLine($"ExportControlLimitMode: {resultB}");

var resultC = await client.ReadHoldingRegisters<Float32>(SunspecConsts.ExportControlSiteLimit);
Console.WriteLine($"ExportControlSiteLimit: {resultC}");

var resultD = await client.ReadHoldingRegisters<Float32>(SunspecConsts.ExternalProductionMaxPower);
Console.WriteLine($"ExternalProductionMaxPower: {resultD}");

//var result = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_Max_Energy);
//Console.WriteLine($"Battery_1_Max_Energy: {result}");

//var resultE = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_Rated_Energy);
//Console.WriteLine($"Battery_1_Rated_Energy: {resultE}");

//var resultF = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_Available_Energy);
//Console.WriteLine($"Battery_1_Lifetime_Export_Energy_Counter: {resultF}");

//var resultG = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Battery_1_State_of_Health);
//Console.WriteLine($"Battery_1_State_of_Health: {resultG}");

//var resultA = await client.ReadHoldingRegisters<UInt32>(SunspecConsts.AdvancedPwrControlEn);
//Console.WriteLine($"AdvancedPwrControlEn: {resultA}");

//var resultB = await client.ReadHoldingRegisters<UInt32>(SunspecConsts.ReactivePwrConfig);
//Console.WriteLine($"ReactivePwrConfig: {resultB}");

////await client.WriteSingleRegister(SunspecConsts.Storage_Control_Mode, (ushort)4);

//var result1 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Storage_Control_Mode);
//Console.WriteLine($"Storage_Control_Mode: {result1}");

//var result2 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Storage_AC_Charge_Policy);
//Console.WriteLine($"Storage_AC_Charge_Policy: {result2}");

//var result3 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Storage_AC_Charge_Limit);
//Console.WriteLine($"Storage_AC_Charge_Limit: {result3}");

//var result4 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Storage_Backup_Reserved_Setting);
//Console.WriteLine($"Storage_Backup_Reserved_Setting: {result4}");

//var result5 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Storage_Charge_Discharge_Default_Mode);
//Console.WriteLine($"Storage_Charge_Discharge_Default_Mode: {result5}");

////await client.WriteSingleRegister(SunspecConsts.Remote_Control_Command_Timeout, (uint)30);
//var result6 = await client.ReadHoldingRegisters<UInt32>(SunspecConsts.Remote_Control_Command_Timeout);
//Console.WriteLine($"Remote_Control_Command_Timeout: {result6}");

////await client.WriteSingleRegister(SunspecConsts.Remote_Control_Command_Mode, (ushort)3);
//var result7 = await client.ReadHoldingRegisters<UInt16>(SunspecConsts.Remote_Control_Command_Mode);
//Console.WriteLine($"Remote_Control_Command_Mode: {result7}");

////await client.WriteSingleRegister(SunspecConsts.Remote_Control_Charge_Limit, 1500f);
//var result8 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Remote_Control_Charge_Limit);
//Console.WriteLine($"Remote_Control_Charge_Limit: {result8}");


//var result9 = await client.ReadHoldingRegisters<Float32>(SunspecConsts.Remote_Control_Command_Discharge_Limit);
//Console.WriteLine($"Remote_Control_Command_Discharge_Limit: {result9}");


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