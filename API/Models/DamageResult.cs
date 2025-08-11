namespace HasarTespitiMVC.Models
{
    public class DamageResult
    {   
        public int Id { get; set; }  
        public int damage_id { get; set; }
        public string damage_type { get; set; }
        public string part { get; set; }
        public double iou { get; set; }
        public double[] bbox { get; set; }

        // Ek sütunlar (örnek amaçlı statik değerler, sonradan Python'dan alınabilir)
        public string action { get; set; }
        public double repair_duration { get; set; }
        public double disassembly_time { get; set; }
        public double paint_duration { get; set; }
        public string severity { get; set; }
        public string confidence_level { get; set; }


    }
}
