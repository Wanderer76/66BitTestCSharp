using FootballCatalog.Models;

namespace FootballCatalog.Repository;

public interface IGenderRepository
{
    Task<Gender> GetGenderByNameAsync(string name);
    Task<List<Gender>> GetAllAsync();
}