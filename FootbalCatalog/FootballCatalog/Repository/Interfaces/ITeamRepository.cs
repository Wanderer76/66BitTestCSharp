using FootballCatalog.Models;

namespace FootballCatalog.Repository;

public interface ITeamRepository
{
    Task<Team?> GetTeamByNameAsync(string name);
    Task<Team> CreateTeamAsync(Team team);
    Task<List<Team>> GetAllAsync();
}