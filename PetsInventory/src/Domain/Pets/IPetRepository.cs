namespace Domain.Pets;

public interface IPetRepository
{
    Task<List<Pet>> GetAll();
    Task<Pet?> GetByIdAsync(PetId id);
    Task<bool> ExistsAsync(PetId id);
    void Add(Pet pet);
    void Update(Pet pet);
    void Remove(Pet pet);
}
