/* 
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: TUFDTO class is created for storing all the converted data before json serialization is done upon the class to turn it into appropriate string format
 * Created: 13.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 16.03.2023
 * Notes: 
 */



namespace EntryProject_TUFAPI.Models.DTO
{
    public class TUFDTO
    {
        // Define all TUF data as properties with appropriate data type
        public string? date { get; set; }
        public float flowRate { get; set; }
        public float energyFlowRate { get; set; }
        public float velocity { get; set; }
        public float fluidSoundSpeed { get; set; }
        public int positiveAccumulator { get; set; }
        public float positiveDecimalFraction { get; set; }
        public int negativeAccumulator { get; set; }
        public float negativeDecimalFraction { get; set; }
        public int positiveEnergyAccumulator { get; set; }
        public float positiveEnergyDecimalFraction { get; set; }
        public int negativeEnergyAccumulator { get; set; }
        public float negativeEnergyDecimalFraction { get; set; }
        public int netAccumulator { get; set; }
        public float netDecimalFraction { get; set; }
        public int netEnergyAccumulator { get; set; }
        public float netEnergyDecimalFraction { get; set; }
        public float temperature1Inlet { get; set; }
        public float temperature2Outlet { get; set; }
        public float analogInputAI3 { get; set; }
        public float analogInputAI4 { get; set; }
        public float analogInputAI5 { get; set; }
        public float currentInputAtAI3_1 { get; set; }
        public float currentInputAtAI3_2 { get; set; }
        public float currentInputAtAI3_3 { get; set; }

        public string systemPassword { get; set; }
        public string passwordForHardware { get; set; }
        public string calendarDateAndTime { get; set; }
        public string dayAndHourForAutoSave { get; set; }


        public Int16 keyToInput { get; set; }
        public Int16 goToWindow { get; set; }
        public Int16 lcdBacklitLightsForNumberOfSeconds { get; set; }
        public Int16 timesForBeeper { get; set; }
        public Int16 pulsesLeftForOCT { get; set; }
        public string? errorCode { get; set; }
        public float pt100ResistanceOfInlet { get; set; }
        public float pt100ResistanceOfOutlet { get; set; }
        public float totalTravelTime { get; set; }
        public float deltaTravelTime { get; set; }
        public float upstreamTravelTime { get; set; }
        public float downstreamTravelTime { get; set; }
        public float outputCurrent { get; set; }
        public string? workingStepAndSignQuality { get; set; }
        public Int16 upstreamStrength { get; set; }
        public Int16 downstreamStrength { get; set; }
        public Int16 languageUsedInUserInterface { get; set; }
        public float theRateOfTheMeasuredTravelTimeByTheCalculatedTravelTime { get; set; }
        public float reynoldsNumber { get; set; }
    }
}
