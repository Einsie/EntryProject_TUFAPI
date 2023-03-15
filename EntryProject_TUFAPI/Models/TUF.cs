using System.Text;
using System.Net;

namespace EntryProject_TUFAPI.Models
{
    public class TUF
    {
        private List<registerDataStruct> _TUFRegister = new List<registerDataStruct>();
        private string _date;

        public string date { get {return _date ;} }
        public List<registerDataStruct> TUFRegisterList { get {return _TUFRegister;} }

        public TUF()
        {
            GetTUFData();
        }

        private void GetTUFData()
        {

            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead("http://tuftuf.gambitlabs.fi/feed.txt"))
            using (StreamReader streamR = new StreamReader(stream))
            {
                _date = streamR.ReadLine();

                while (streamR.Peek() > -1)
                {

                    string streamRLine = streamR.ReadLine();
                    char[] lineResult;
                    StringBuilder idBuilder = new StringBuilder();
                    StringBuilder bitIntegralBuilder = new StringBuilder();
                    bool isDigitID = true;


                    foreach (char c in streamRLine)
                    {
                        if (char.IsDigit(c) && isDigitID)
                        {
                            idBuilder.Append(c);
                        }
                        else if (char.IsDigit(c))
                        {
                            bitIntegralBuilder.Append(c);
                        }
                        else 
                        { 
                            isDigitID = false;
                        }
                    }

                    int idInt;
                    UInt16 bitIntegral;
                    bool parseIdResult = int.TryParse(idBuilder.ToString(), out idInt);
                    bool parseValueResult = UInt16.TryParse(bitIntegralBuilder.ToString(), out bitIntegral);


                    _TUFRegister.Add(new registerDataStruct(idInt, bitIntegral));
                }
            }
        }

        public record struct registerDataStruct(
            int id,
            UInt16 bitIntegralValue
        );


    }
}
