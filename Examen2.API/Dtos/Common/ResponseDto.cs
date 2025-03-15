using System.Text.Json.Serialization;

namespace Examen2.API.Dtos.Common
{
    public class ResponseDto<T> 
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}