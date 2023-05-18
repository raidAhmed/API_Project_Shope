namespace Agricultural.Application.Interfaces.Common
    
{
    public interface ICustomConventer
    {
        public string EncodeJson(object obj);
        public T DecodeJson<T>(string json) where T:class;
        //public List<GoverReportVM> DecodeJson(string json);
    }
}
