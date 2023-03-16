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

using System.Collections;

namespace EntryProject_TUFAPI.Models.DTO
{
    public class TUFDTO
    {
        public string? Date { get; set; }
        public float FlowRate { get; set; }
        public float EnergyFlowRate { get; set; }
        public float Velocity { get; set; }
        public float FluidSoundSpeed { get; set; }
        public int PositiveAccumulator { get; set; }
        public float PositiveDecimalFraction { get; set; }
        public int NegativeAccumulator { get; set; }
        public float NegativeDecimalFraction { get; set; }
        public int PositiveEnergyAccumulator { get; set; }
        public float PositiveEnergyDecimalFraction { get; set; }
        public int NegativeEnergyAccumulator { get; set; }
        public float NegativeEnergyDecimalFraction { get; set; }
        public int NetAccumulator { get; set; }
        public float NetDecimalFraction { get; set; }
        public int NetEnergyAccumulator { get; set; }
        public float NetEnergyDecimalFraction { get; set; }
        public float Temperature1Inlet { get; set; }
        public float Temperature2Outlet { get; set; }
        public float AnalogInputAI3 { get; set; }
        public float AnalogInputAI4 { get; set; }
        public float AnalogInputAI5 { get; set; }
        public float CurrentInputAtAI3_1 { get; set; }
        public float CurrentInputAtAI3_2 { get; set; }
        public float CurrentInputAtAI3_3 { get; set; }



        public Int16 KeyToInput { get; set; }
        public Int16 GoToWindow { get; set; }
        public Int16 LCDBacklitLightsForNumberOfSeconds { get; set; }
        public Int16 TimesForBeeper { get; set; }
        public Int16 PulsesLeftForOCT { get; set; }
        public string? ErrorCode { get; set; }
        public float PT100ResistanceOfInlet { get; set; }
        public float PT100ResistanceOfOutlet { get; set; }
        public float TotalTravelTime { get; set; }
        public float DeltaTravelTime { get; set; }
        public float UpstreamTravelTime { get; set; }
        public float DownstreamTravelTime { get; set; }
        public float OutputCurrent { get; set; }
        public Int16 WorkingStepAndSignQuality { get; set; }
        public Int16 UpstreamStrength { get; set; }
        public Int16 DownstreamStrength { get; set; }
        public Int16 LanguageUsedInUserInterface { get; set; }
        public float TheRateOfTheMeasuredTravelTimeByTheCalculatedTravelTime { get; set; }
        public float ReynoldsNumber { get; set; }



        //public record struct Real4DataStruct(
        //    string name,
        //    float BitIntegralValue
        //);
        //public record struct LongDataStruct(
        //    int id,
        //    ushort bitIntegralValue
        //);
        //public record struct BCDDataStruct(
        //    int id,
        //    ushort bitIntegralValue
        //);

    }
}
