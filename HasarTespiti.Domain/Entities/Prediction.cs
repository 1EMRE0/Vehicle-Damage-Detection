using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasarTespiti.Domain.Enums;

namespace HasarTespiti.Domain.Entities
{
    public class Prediction
    {
        public Guid Id { get; set; }

        public Guid PhotoId { get; set; }

        public Photo Photo { get; set; } = null!;

        public  DamageType DamageType { get; set; }

        public string? PartName { get; set; }
        public double Confidence { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int w { get; set; }
        public int H { get; set; }


    }
}
