using FootballCatalog.Models;

namespace FootballCatalog.Repository;

public interface IGenderRepository
{
    Task<Gender> GetGenderByName(string name);
    Task<List<Gender>> GetAll();
}