namespace EntryProject_TUFAPI.Models.DTO
{
    public class TUFDTO
    {
        public string Date { get; set; }
        public List<Real4DataStruct> Real4Data { get; set; }
        public List<LongDataStruct> LongData { get; set; }
        public List<BCDDataStruct> BCDData { get; set; }



        public record struct Real4DataStruct(
            string name,
            float BitIntegralValue
        );
        public record struct LongDataStruct(
            int id,
            ushort bitIntegralValue
        );
        public record struct BCDDataStruct(
            int id,
            ushort bitIntegralValue
        );

    }
}
