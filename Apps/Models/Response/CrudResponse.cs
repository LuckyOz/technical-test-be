
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Apps.Models.Response
{
    public class CrudResponse
    {
        [JsonPropertyName("id"), JsonProperty("id")]
        public int Id { get; set; }

        [JsonPropertyName("nama"), JsonProperty("nama")]
        public string? Nama { get; set; }

        [JsonPropertyName("status"), JsonProperty("status")]
        public short Status { get; set; }

        [JsonPropertyName("created"), JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("updated"), JsonProperty("updated")]
        public DateTime Updated { get; set; }
    }
}
