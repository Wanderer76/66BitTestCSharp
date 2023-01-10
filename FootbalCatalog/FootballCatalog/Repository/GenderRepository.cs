using FootballCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballCatalog.Repository;

public class GenderRepository : IGenderRepository
{
    private ApplicationDbContext DbContext;

    public GenderRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Gender> GetGenderByNameAsync(string name)
    {
        return await DbContext.Genders.Where(gender => gender.Name == name).FirstAsync();
    }

    public async Task<List<Gender>> GetAllAsync()
    {
        return await DbContext.Genders.ToListAsync();
    }
}