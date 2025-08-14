using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasarTespiti.Domain.Entities;

namespace HasarTespiti.Application.Contracts
{
    public interface IPhotoRepository
    {
        Task<Photo> AddAsync(Photo photo, CancellationToken ct = default);

    }
}


// photo entitysi üzerinde yapılacak tüm veritabanı işemlerini tanımlar.
//yalnızca imzaları içerir . gerçek kod repository katmanında
//kodun bağımlılıklarını azaltmak .