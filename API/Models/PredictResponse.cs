using System.Collections.Generic;

namespace HasarTespitiMVC.Models
{
    public class PredictResponse
    {
        public List<DamageResult> results { get; set; }
        public string image_base64 { get; set; }
    }
}
