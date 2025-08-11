using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("damage_results")]
    public class DamageResult
    {
        [Key]
        public int damage_result_id { get; set; }  
        public int damage_id { get; set; }
        public string damage_type { get; set; }
        public string part { get; set; }
        public double iou { get; set; }
        public double[] bbox { get; set; }

        public string damage_action { get; set; }
        public double repair_duration { get; set; }
        public double disassembly_time { get; set; }
        public double paint_duration { get; set; }
        public string severity { get; set; }
        public string confidence_level { get; set; }


    }
}
