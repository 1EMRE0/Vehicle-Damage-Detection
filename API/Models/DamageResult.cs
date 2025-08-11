namespace HasarTespitiMVC.Models
{
    public class DamageResult
    {
        public int damage_id { get; set; }
        public string damage_type { get; set; }
        public string part { get; set; }
        public double iou { get; set; }
        public double[] bbox { get; set; }

        // Ek sütunlar (örnek amaçlı statik değerler, sonradan Python'dan alınabilir)
        public string islem { get; set; }
        public double tamir_suresi { get; set; }
        public double soktak_suresi { get; set; }
        public double boya_suresi { get; set; }
        public string yogunluk { get; set; }
        public string eminlik { get; set; }
    }
}
