/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: TUF class handles the receival of all necessary data from Gambit's
 * text file hosted online, parses and compiles this data into date and list of id and value pairs in
 * local variables. These can then be accessed through accessor properties by other parts of API.
 * Created: 13.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 16.03.2023
 * Notes: 
 */

// Using statements necessary for function:
using System.Text;
using System.Net;

namespace EntryProject_TUFAPI.Models
{
    public class TUF
    {
        // create local class variables
        private List<UInt16> _TUFRegister;
        private string _date;

        // Class accessor properties for local variables for defining allowed use for them as only GET
        public string date { get {return _date ;} }
        public List<UInt16> TUFRegisterList { get {return _TUFRegister;} }


        // Constructor for TUF class
        public TUF()
        {
            //initialise local class variables
            _TUFRegister = new List<UInt16>();
            _date = String.Empty;

            // call GetTUFData method to begin the process of data access and storage into class variables
            GetTUFData();
        }


        /* Method: GetTUFData()
         * Description: Internal method which creates an access to the Gambit's online text file containing
         * TUF data registers, then parses this information into usable values for later conversion
         * and stores these into appropriate class variables
         * 
         * Notes:
         */
        private void GetTUFData()
        {
            // using statements which will create the necessary resources for access into and processing Gambit's online TUF Data, existing for duration of method.
            using (WebClient client = new WebClient()) // creates a webclient required to gain access to online directories over internal ones
            using (Stream stream = client.OpenRead("http://tuftuf.gambitlabs.fi/feed.txt")) // a path into the Gambit's TUF data online
            using (StreamReader streamR = new StreamReader(stream)) // streamreader object for processing the information in the given online directory
            {
                _date = streamR.ReadLine(); // set _date into TUF data's date, set into first line in Gambit's text file

                while (streamR.Peek() > -1) // while loop going through every line in text file in order until end of file
                {

                    string streamRLine = streamR.ReadLine(); // go through the next line with Streamreader in text file and store it into temporary string called streamRLine
                    StringBuilder bitIntegralBuilder = new StringBuilder(); // a stringbuilder object for sperating the integral value of 16 bits into its own string from StreamRLine
                    bool isDigitBitIntegral = false;  // Boolean for confirming if current character in string is now part of 16bit integral value, in text file ID and Value separated by ':' symbol which we're looking for

                    // foreach loop for going through every individual character stored in streamRLine and determine if the char is a digit or not, if not, set isDigitID to false
                    foreach (char c in streamRLine)
                    {
                        if (isDigitBitIntegral && char.IsDigit(c))
                        {
                            bitIntegralBuilder.Append(c); // when isDigitBitIntegral is true and current character is a digit, add current character being tested into bitIntegralBuilder Object
                        }
                        else if (!char.IsDigit(c))
                        {
                            isDigitBitIntegral = true; // the ':' symbol separating id and values was found, thus isDigitBitIntegral is set to false for future foreach loops
                        }
                    }

                    // parse the strings in bitIntegralBuilder and temporarily store it into bitIntegral
                    UInt16 bitIntegral;
                    bool parseValueResult = UInt16.TryParse(bitIntegralBuilder.ToString(), out bitIntegral);

                    // add a new registerDataStruct into the internal _TUFRegister list with parsed data values
                    _TUFRegister.Add(bitIntegral);
                }
            }
        }
    }
}
