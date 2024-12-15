using Domain.Pets;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Pet> Pets { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
