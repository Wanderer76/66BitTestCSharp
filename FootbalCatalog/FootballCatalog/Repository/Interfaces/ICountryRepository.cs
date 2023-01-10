using FootballCatalog.Models;

namespace FootballCatalog.Repository;

public interface ICountryRepository
{
    Task<Country> GetCountryByNameAsync(string name);
    Task<List<Country>> GetAllAsync();
}