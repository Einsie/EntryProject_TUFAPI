/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: This class handles the receival of all necessary data from Gambit's
 * text file hosted online, parses and compiles this data into date and list of id and value pairs in
 * local variables. These can then be accessed through accessor properties by other parts of API.
 * Created: 13.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 15.03.2023
 * notes: 
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

        // Class access properties for local variables for defining allowed use for them as only GET
        public string date { get {return _date ;} }
        public List<UInt16> TUFRegisterList { get {return _TUFRegister;} }

        public TUF()
        {
            //initialise local class variables
            _TUFRegister = new List<UInt16>();
            _date = "";

            // call GetTUFData method to begin the process of data access and storage into class variables
            GetTUFData();
        }


        /* Method: GetTUFData
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
                    StringBuilder idBuilder = new StringBuilder(); // a stringbuilder object for separating ID from StreamRLine
                    StringBuilder bitIntegralBuilder = new StringBuilder(); // a stringbuilder object for sperating the integral value of 16 bits into its own string from StreamRLine
                    bool isDigitID = true;  // Boolean for confirming if current character in string is still part of ID or not, in text file ID and Value separated by ':' symbol we're looking for

                    // foreach loop for going through every individual character stored in streamRLine and determine if the char is a digit or not, if not, set isDigitID to false
                    foreach (char c in streamRLine)
                    {
                        if (char.IsDigit(c) && isDigitID)
                        {
                            idBuilder.Append(c); // add current character being tested into idBuilder object
                        }
                        else if (char.IsDigit(c))
                        {
                            bitIntegralBuilder.Append(c); // when isDigitID is false, add current character being tested into bitIntegralBuilder Object
                        }
                        else 
                        { 
                            isDigitID = false; // the ':' symbol separating id and values was found, thus isDigitID is set to false for future foreach loops
                        }
                    }

                    // parse the strings in idBuilder and bitIntegralBuilder and temporarily store them into idInt and bitIntegral respectively
                    //int idInt;
                    UInt16 bitIntegral;
                    //bool parseIdResult = int.TryParse(idBuilder.ToString(), out idInt);
                    bool parseValueResult = UInt16.TryParse(bitIntegralBuilder.ToString(), out bitIntegral);

                    // add a new registerDataStruct into the internal _TUFRegister list with parsed data values
                    _TUFRegister.Add(bitIntegral);
                }
            }
        }


        // RegisterDataStruct: structure used for storing relevant information into ID and the 16bit IntegralValue pairs
        public record struct registerDataStruct(
            int id,
            UInt16 bitIntegralValue
        );
    }
}
