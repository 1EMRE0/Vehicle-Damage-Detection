using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasarTespiti.Domain.Entities
{
    public class AppUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = "";

        public ICollection<Photo> Photos { get; set; } = new List<Photo>();

        
    }
}













// sisteme giriş yapan ya da foto yükleyen her kullanıcıyı temsl eder
// bir kullanıcı birden fazla foto yükleyebilir.