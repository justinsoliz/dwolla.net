using Newtonsoft.Json;

namespace Dwolla.Models
{
    public class DwollaResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        [JsonProperty("Response")]
        public T Result { get; set; }
    }
}
