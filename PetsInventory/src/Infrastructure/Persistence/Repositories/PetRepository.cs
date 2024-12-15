using Domain.Pets;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PetRepository : IPetRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PetRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void Add(Pet pet) => _dbContext.Pets.AddAsync(pet);

    public Task<bool> ExistsAsync(PetId id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Pet>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Pet?> GetByIdAsync(PetId id) => 
        await _dbContext.Pets.SingleOrDefaultAsync(p => p.Id == id);

    public void Remove(Pet pet)
    {
        throw new NotImplementedException();
    }

    public void Update(Pet pet)
    {
        throw new NotImplementedException();
    }
}
