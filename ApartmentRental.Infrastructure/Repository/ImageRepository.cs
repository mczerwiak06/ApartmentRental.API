using ApartmentRental.Infrastructure.Entities;

namespace ApartmentRental.Infrastructure.Repository;

public class ImageRepository : IImageRepository
{
    public Task AddAsync(Image entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Image>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Image> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Image entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
