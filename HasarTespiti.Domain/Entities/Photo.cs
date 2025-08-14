using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasarTespiti.Domain.Entities
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string OriginalPath { get; set; } = "";     // kullanıcının yüklediği fotoğraf yolu.

        public string? AnnotatedPath { get; set; }   // API den gelen fotoğrafın yolu.

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  //fotoğrafın sisteme yüklendiği zaman.   UtcNow standart zaman için 

        public Guid UploadedById { get; set; }

        public AppUser UploadedBy { get; set; } = null!;

        public ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();
    }
}




//sisteme yüklenen tek bir  fotoğrafın temsili.
// poco 
//EF core bu sınıfı kullanarak veritabanında photos tablosu oluşur.