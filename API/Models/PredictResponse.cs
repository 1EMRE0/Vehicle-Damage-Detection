using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace API.Models
{
    public class PredictResponse
    {   
        public string status { get; set; }
        public string message { get; set; }
        public List<DamageResult> results { get; set; }

        [JsonPropertyName("image_base64")]
        public string image_base64 { get; set; }
    }
}
