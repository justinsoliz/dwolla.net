using Newtonsoft.Json;

namespace Dwolla.Models
{
    public class DwollaContact
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Group { get; set; }

        [JsonProperty("Type")]
        public string ContactType { get; set; }

        [JsonProperty("Image")]
        public string ImageUrl { get; set; }
    }
}
