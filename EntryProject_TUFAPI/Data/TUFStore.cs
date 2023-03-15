using EntryProject_TUFAPI.Models;
using EntryProject_TUFAPI.Models.DTO;

namespace EntryProject_TUFAPI.Data
{
    public class TUFStore
    {
        private static TUF newTUF = new TUF();

        public TUFDTO _TUFList = new TUFDTO {
            Date = newTUF.date,
            Real4Data = new List<TUFDTO.Real4DataStruct> { },
            LongData = new List<TUFDTO.LongDataStruct> { },
            BCDData = new List<TUFDTO.BCDDataStruct> { }
        };




        //float value = BitConverter.ToSingle(byte32Array, 0);
        //float value = BitConverter.ToInt32(byte32Array, 0);

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
