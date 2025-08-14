using System;
using System.Threading;
using System.Threading.Tasks;
using HasarTespiti.Domain.Entities;
using HasarTespiti.Application.Contracts; // IPhotoService yolu (senin klasör yapına göre değişebilir)


public class PhotoService : IPhotoService
{
    private readonly IPhotoRepository _photoRepository;

    public PhotoService(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<Photo> AddPhotoAsync(Photo photo, CancellationToken ct = default)
    {
        if (photo == null)
            throw new ArgumentNullException(nameof(photo));

        if (string.IsNullOrWhiteSpace(photo.OriginalPath))
            throw new ArgumentException("Fotoğraf yolu boş olamaz.", nameof(photo.OriginalPath));

        if (photo.CreatedAt == default)
            photo.CreatedAt = DateTime.UtcNow;

        return await _photoRepository.AddAsync(photo, ct);
    }
}
