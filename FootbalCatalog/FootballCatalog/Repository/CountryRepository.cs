using FootballCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballCatalog.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext DbContext;

    public CountryRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Country> GetCountryByName(string name)
    {
        return await DbContext.Countries.Where(country => country.Name == name).FirstAsync();
    }

    public async Task<List<Country>> GetAll()
    {
        return await DbContext.Countries.ToListAsync();
    }
}