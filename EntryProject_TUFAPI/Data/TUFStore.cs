/* 
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: 
 * Created: 13.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 15.03.2023
 * notes: 
 */

using EntryProject_TUFAPI.Models;
using EntryProject_TUFAPI.Models.DTO;
using System.Text.Json;
using System.Collections;

namespace EntryProject_TUFAPI.Data
{
    public class TUFStore
    {

        private TUFDTO _TUFList;

        public string TUFListJson { get { return JsonSerializer.Serialize(_TUFList); } }

        public TUFStore(TUF TUFData)
        {
            _TUFList = new TUFDTO();
            TUFDataConversion(TUFData);
        }


        private void TUFDataConversion(TUF TUFData)
        {
            _TUFList.Date = TUFData.date;
            _TUFList.FlowRate = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[0], TUFData.TUFRegisterList[1]));
            _TUFList.EnergyFlowRate = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[2], TUFData.TUFRegisterList[3]));
            _TUFList.Velocity = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[4], TUFData.TUFRegisterList[5]));
            _TUFList.FluidSoundSpeed = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[6], TUFData.TUFRegisterList[7]));
            _TUFList.PositiveAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[8], TUFData.TUFRegisterList[9]));
            _TUFList.PositiveDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[10], TUFData.TUFRegisterList[11]));
            _TUFList.NegativeAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[12], TUFData.TUFRegisterList[13]));
            _TUFList.NegativeDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[14], TUFData.TUFRegisterList[15]));
            _TUFList.PositiveEnergyAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[16], TUFData.TUFRegisterList[17]));
            _TUFList.PositiveEnergyDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[18], TUFData.TUFRegisterList[19]));
            _TUFList.NegativeEnergyAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[20], TUFData.TUFRegisterList[21]));
            _TUFList.NegativeEnergyDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[22], TUFData.TUFRegisterList[23]));
            _TUFList.NetAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[24], TUFData.TUFRegisterList[25]));
            _TUFList.NetDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[26], TUFData.TUFRegisterList[27]));
            _TUFList.NetEnergyAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[28], TUFData.TUFRegisterList[29]));
            _TUFList.NetEnergyDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[30], TUFData.TUFRegisterList[31]));
            _TUFList.Temperature1Inlet = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[32], TUFData.TUFRegisterList[33]));
            _TUFList.Temperature2Outlet = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[34], TUFData.TUFRegisterList[35]));
            _TUFList.AnalogInputAI3 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[36], TUFData.TUFRegisterList[37]));
            _TUFList.AnalogInputAI4 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[38], TUFData.TUFRegisterList[39]));
            _TUFList.AnalogInputAI5 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[40], TUFData.TUFRegisterList[41]));
            _TUFList.CurrentInputAtAI3_1 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[42], TUFData.TUFRegisterList[43]));
            _TUFList.CurrentInputAtAI3_2 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[44], TUFData.TUFRegisterList[45]));
            _TUFList.CurrentInputAtAI3_3 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[46], TUFData.TUFRegisterList[47]));


            _TUFList.KeyToInput = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[58]));
            _TUFList.GoToWindow = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[59]));
            _TUFList.LCDBacklitLightsForNumberOfSeconds = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[60]));
            _TUFList.TimesForBeeper = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[61]));
            _TUFList.PulsesLeftForOCT = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[61]));
            _TUFList.ErrorCode = Convert.ToString(Byte16Conversion(TUFData.TUFRegisterList[71])[0], 2).PadLeft(8, '0');
            _TUFList.ErrorCode += Convert.ToString(Byte16Conversion(TUFData.TUFRegisterList[71])[1], 2).PadLeft(8, '0');

            _TUFList.PT100ResistanceOfInlet = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[76], TUFData.TUFRegisterList[77]));
            _TUFList.PT100ResistanceOfOutlet = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[78], TUFData.TUFRegisterList[79]));
            _TUFList.TotalTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[80], TUFData.TUFRegisterList[81]));
            _TUFList.DeltaTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[82], TUFData.TUFRegisterList[83]));
            _TUFList.UpstreamTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[84], TUFData.TUFRegisterList[85]));
            _TUFList.DownstreamTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[86], TUFData.TUFRegisterList[87]));
            _TUFList.OutputCurrent = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[88], TUFData.TUFRegisterList[89]));

            _TUFList.WorkingStepAndSignQuality = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[91]));
            _TUFList.UpstreamStrength = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[92]));
            _TUFList.DownstreamStrength = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[93]));
            _TUFList.LanguageUsedInUserInterface = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[95]));

            _TUFList.TheRateOfTheMeasuredTravelTimeByTheCalculatedTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[96], TUFData.TUFRegisterList[97]));
            _TUFList.ReynoldsNumber = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[98], TUFData.TUFRegisterList[99]));
        }

        // = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[], TUFData.TUFRegisterList[]));
        // = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[], TUFData.TUFRegisterList[]));

        private byte[] Byte16ToByte32Conversion(UInt16 firstRegisterValue, UInt16 secondRegisterValue)
        {
            byte[] byte16Array1 = BitConverter.GetBytes(firstRegisterValue);
            byte[] byte16Array2 = BitConverter.GetBytes(secondRegisterValue);
            byte[] byte32Array = new byte[4];
            byte32Array[0] = byte16Array1[0];
            byte32Array[1] = byte16Array1[1];
            byte32Array[2] = byte16Array2[0];
            byte32Array[3] = byte16Array2[1];
            return byte32Array;
        }

        private byte[] Byte16Conversion(UInt16 registerValue)
        {
            return BitConverter.GetBytes(registerValue);
        }

        private byte[] Byte16ToByte48Conversion(UInt16 firstRegisterValue, UInt16 secondRegisterValue, UInt16 thirdRegisterValue)
        {
            byte[] byte16Array1 = BitConverter.GetBytes(firstRegisterValue);
            byte[] byte16Array2 = BitConverter.GetBytes(secondRegisterValue);
            byte[] byte16Array3 = BitConverter.GetBytes(thirdRegisterValue);
            byte[] byte48Array = new byte[6];
            byte48Array[0] = byte16Array1[0];
            byte48Array[1] = byte16Array1[1];
            byte48Array[2] = byte16Array2[0];
            byte48Array[3] = byte16Array2[1];
            byte48Array[4] = byte16Array3[0];
            byte48Array[5] = byte16Array3[1];
            return byte48Array;
        }
    }
}
