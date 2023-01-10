using FootballCatalog.Models;

namespace FootballCatalog.Repository;

public interface IFootballerRepository
{
    Task<Footballer> CreateFootballerAsync(Footballer footballer);
    Task<Footballer> UpdateFootballerAsync(Footballer footballer);
    Task DeleteFootballerByIdAsync(int id);
    Task<Footballer> FindFootballerByIdAsync(int id);
    Task<List<Footballer>> GetAllAsync();
}