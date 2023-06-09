﻿/* 
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: TUFStore class upon creation creates and stores the TUFDTO object, does the data conversion
 * from the TUF object sent to it and initializing TUFDTO variables with them. This TUFDTO can be accessed by the
 * controller as a Json serialized string through the TUFDataJson accessor
 * Created: 13.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 16.03.2023
 * Notes: 
 */


// Using statements necessary for function:
using EntryProject_TUFAPI.Models;
using EntryProject_TUFAPI.Models.DTO;

namespace EntryProject_TUFAPI.Data
{
    public class TUFStore
    {
        // create the TUFDTO object
        private TUFDTO _TUFDTO;

        // accessor property for the TUFDTO
        public TUFDTO TUFDataJson { get { return _TUFDTO; } }


        // TUFStore constructor with parameter for TUF object
        public TUFStore(TUF TUFData)
        {
            _TUFDTO = new TUFDTO(); // initialise _TUFDTO
            TUFDataConversion(TUFData); // begin conversion with the received TUF object
        }

        /* Method: TUFDataConversion(TUF TUFData)
         * Description: With received TUF object, initializes the class properties of _TUFDTO with values this class
         * converts using BitConverter and the three local class methods below 
         * Parameter: TUFData of type TUF which holds all the base register values necessary for conversion
         * 
         * Notes: TUFDTO.ErrorCode property initialising solution used based on answer from user Kelsey at https://stackoverflow.com/questions/3581674/converting-a-byte-to-a-binary-string-in-c-sharp
         * used for converting byte array element into string and still showing all 8 bits even if their values are 0 using .PadLeft(8, '0')
         */
        private void TUFDataConversion(TUF TUFData)
        {
            _TUFDTO.date = TUFData.date;
            _TUFDTO.flowRate = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[0], TUFData.TUFRegisterList[1]));
            _TUFDTO.energyFlowRate = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[2], TUFData.TUFRegisterList[3]));
            _TUFDTO.velocity = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[4], TUFData.TUFRegisterList[5]));
            _TUFDTO.fluidSoundSpeed = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[6], TUFData.TUFRegisterList[7]));
            _TUFDTO.positiveAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[8], TUFData.TUFRegisterList[9]));
            _TUFDTO.positiveDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[10], TUFData.TUFRegisterList[11]));
            _TUFDTO.negativeAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[12], TUFData.TUFRegisterList[13]));
            _TUFDTO.negativeDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[14], TUFData.TUFRegisterList[15]));
            _TUFDTO.positiveEnergyAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[16], TUFData.TUFRegisterList[17]));
            _TUFDTO.positiveEnergyDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[18], TUFData.TUFRegisterList[19]));
            _TUFDTO.negativeEnergyAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[20], TUFData.TUFRegisterList[21]));
            _TUFDTO.negativeEnergyDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[22], TUFData.TUFRegisterList[23]));
            _TUFDTO.netAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[24], TUFData.TUFRegisterList[25]));
            _TUFDTO.netDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[26], TUFData.TUFRegisterList[27]));
            _TUFDTO.netEnergyAccumulator = BitConverter.ToInt32(Byte16ToByte32Conversion(TUFData.TUFRegisterList[28], TUFData.TUFRegisterList[29]));
            _TUFDTO.netEnergyDecimalFraction = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[30], TUFData.TUFRegisterList[31]));
            _TUFDTO.temperature1Inlet = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[32], TUFData.TUFRegisterList[33]));
            _TUFDTO.temperature2Outlet = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[34], TUFData.TUFRegisterList[35]));
            _TUFDTO.analogInputAI3 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[36], TUFData.TUFRegisterList[37]));
            _TUFDTO.analogInputAI4 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[38], TUFData.TUFRegisterList[39]));
            _TUFDTO.analogInputAI5 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[40], TUFData.TUFRegisterList[41]));
            _TUFDTO.currentInputAtAI3_1 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[42], TUFData.TUFRegisterList[43]));
            _TUFDTO.currentInputAtAI3_2 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[44], TUFData.TUFRegisterList[45]));
            _TUFDTO.currentInputAtAI3_3 = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[46], TUFData.TUFRegisterList[47]));


            _TUFDTO.systemPassword = BCDConversion(Byte16ToByte32Conversion(TUFData.TUFRegisterList[48], TUFData.TUFRegisterList[49]));
            _TUFDTO.passwordForHardware = BCDConversion(Byte16Conversion(TUFData.TUFRegisterList[50]));
            _TUFDTO.calendarDateAndTime = BCDConversion(Byte16ToByte48Conversion(TUFData.TUFRegisterList[52], TUFData.TUFRegisterList[53], TUFData.TUFRegisterList[54]));
            _TUFDTO.dayAndHourForAutoSave = BCDConversion(Byte16Conversion(TUFData.TUFRegisterList[55]));

            _TUFDTO.keyToInput = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[58]));
            _TUFDTO.goToWindow = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[59]));
            _TUFDTO.lcdBacklitLightsForNumberOfSeconds = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[60]));
            _TUFDTO.timesForBeeper = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[61]));
            _TUFDTO.pulsesLeftForOCT = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[61]));

            // Errorcode requires all 16 bits displayed in string as each bit being on signifies a different error code being returned, check TUF Manual page 44 note (4)
            _TUFDTO.errorCode = Convert.ToString(Byte16Conversion(TUFData.TUFRegisterList[71])[0], 2).PadLeft(8, '0') + "" + Convert.ToString(Byte16Conversion(TUFData.TUFRegisterList[71])[1], 2).PadLeft(8, '0');

            _TUFDTO.pt100ResistanceOfInlet = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[76], TUFData.TUFRegisterList[77]));
            _TUFDTO.pt100ResistanceOfOutlet = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[78], TUFData.TUFRegisterList[79]));
            _TUFDTO.totalTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[80], TUFData.TUFRegisterList[81]));
            _TUFDTO.deltaTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[82], TUFData.TUFRegisterList[83]));
            _TUFDTO.upstreamTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[84], TUFData.TUFRegisterList[85]));
            _TUFDTO.downstreamTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[86], TUFData.TUFRegisterList[87]));
            _TUFDTO.outputCurrent = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[88], TUFData.TUFRegisterList[89]));

            // Each byte of WorkingStepAndSignQuality value has to be displayed separately as their own values 
            _TUFDTO.workingStepAndSignQuality = int.Parse(Convert.ToString(Byte16Conversion(TUFData.TUFRegisterList[91])[0]), System.Globalization.NumberStyles.HexNumber) + " " + int.Parse(Convert.ToString(Byte16Conversion(TUFData.TUFRegisterList[91])[1]), System.Globalization.NumberStyles.HexNumber);

            _TUFDTO.upstreamStrength = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[92]));
            _TUFDTO.downstreamStrength = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[93]));
            _TUFDTO.languageUsedInUserInterface = BitConverter.ToInt16(Byte16Conversion(TUFData.TUFRegisterList[95]));

            _TUFDTO.theRateOfTheMeasuredTravelTimeByTheCalculatedTravelTime = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[96], TUFData.TUFRegisterList[97]));
            _TUFDTO.reynoldsNumber = BitConverter.ToSingle(Byte16ToByte32Conversion(TUFData.TUFRegisterList[98], TUFData.TUFRegisterList[99]));
        }


        /* Method: Byte16ToByte32Conversion(UInt16 firstRegisterValue, UInt16 secondRegisterValue)
         * Description: Converts two TUF register values into bytes and stores them in a byte array which it returns
         * Parameter: FirstRegisterValue of type UInt16 holding a 16bit integral register value
         * Parameter: secondRegisterValue of type UInt16 holding a 16bit integral register value
         * return: returns a byte array with four elements for the four bytes
         * 
         * Notes:
         */
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


        /* Method: Byte16Conversion(UInt16 registerValue)
         * Description: Converts one TUF register value into a byte and stores it in a byte array which it returns
         * Parameter: registerValue of type UInt16 holding a 16bit integral register value
         * return: returns a byte array with two element for the two bytes
         * 
         * Notes:
         */
        private byte[] Byte16Conversion(UInt16 registerValue)
        {
            return BitConverter.GetBytes(registerValue);
        }

        /* Method: Byte16ToByte48Conversion(UInt16 firstRegisterValue, UInt16 secondRegisterValue, UInt16 thirdRegisterValue)
         * Description: Converts three TUF register values into bytes and stores them in a byte array which it returns
         * Parameter: FirstRegisterValue of type UInt16 holding a 16bit integral register value
         * Parameter: secondRegisterValue of type UInt16 holding a 16bit integral register value
         * Parameter: thirdRegisterValue of type UInt16 holding a 16bit integral register value
         * return: returns a byte array with six elements for the six bytes 
         * 
         * Notes:
         */
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



        /* Method: BCDConversion(byte[] inputBytes)
         * Description: This method is used for BCD format TUF data, it splits all bytes in the parameter array to 4 individual bits
         * and converts these back into decimals. These are then returned as a single unified string
         * Parameters: inputBytes of type byte array, this holds all bytes to be converted
         * return: returns BCDOutput of type string, this holds the compilation of all 4 bit decimal values
         * 
         * Notes:
         */
        private string BCDConversion(byte[] inputBytes)
        {
            string BCDOutput = string.Empty;
            foreach (byte b in inputBytes)
            {
                string byteToBeHalved = Convert.ToString(b, 2).PadLeft(8, '0');
                string halfByteFirst = string.Empty;
                string halfByteSecond = string.Empty;
                int bitCounter = 1;

                foreach (char i in byteToBeHalved)
                {
                    if(bitCounter < 5)
                    {
                        halfByteFirst += i;
                    }
                    else
                    {
                        halfByteSecond += i;
                    }
                    bitCounter++;
                }
                BCDOutput += Convert.ToInt16(halfByteFirst, 2) + "" + Convert.ToInt16(halfByteSecond, 2) + " ";
            }
            return BCDOutput;
        }
    }
}
