using FootballCatalog.Models;

namespace FootballCatalog.Repository;

public interface ITeamRepository
{
    Task<Team?> GetTeamByName(string name);
    Task<Team> CreateTeam(Team team);
    Task<List<Team>> GetAll();
}