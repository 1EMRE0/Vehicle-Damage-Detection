using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasarTespiti.Application.Contracts;
using HasarTespiti.Domain.Entities;


public class PhotoRepository : IPhotoRepository
{
    private readonly AppDbContext _db;
    public PhotoRepository(AppDbContext db) => _db = db;

    public async Task<Photo> AddAsync(Photo photo, CancellationToken ct = default)
    {
        
        await _db.Photos.AddAsync(photo, ct);

       
        await _db.SaveChangesAsync(ct);

        
        return photo;
    }
}







