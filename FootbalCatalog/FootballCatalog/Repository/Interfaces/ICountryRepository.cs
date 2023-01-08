using FootballCatalog.Models;

namespace FootballCatalog.Repository;

public interface ICountryRepository
{
    Task<Country> GetCountryByName(string name);
    Task<List<Country>> GetAll();
}