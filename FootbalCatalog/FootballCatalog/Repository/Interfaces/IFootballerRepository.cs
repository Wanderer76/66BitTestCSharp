using FootballCatalog.Models;

namespace FootballCatalog.Repository;

public interface IFootballerRepository
{
    Task<Footballer> CreateAsync(Footballer footballer);
    Task<Footballer> UpdateAsync(Footballer footballer);
    Task DeleteByIdAsync(int id);
    Task<Footballer> FindByIdAsync(int id);
    Task<List<Footballer>> GetAllAsync();
}