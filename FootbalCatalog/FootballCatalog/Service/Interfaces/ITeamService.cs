using FootballCatalog.Models;

namespace FootballCatalog.Service;

public interface ITeamService
{
    Task<Team> GetTeamOrCreate(string name);
    Task<List<string>> GetAll();
}