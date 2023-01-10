using FootballCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballCatalog.Repository;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext DbContext;

    public TeamRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Team?> GetTeamByNameAsync(string name)
    {
        return await DbContext.Teams
            .Where(team => team.Name == name)
            .FirstOrDefaultAsync();
    }

    public async Task<Team> CreateTeamAsync(Team team)
    {
        await DbContext.Teams.AddAsync(team);
        await DbContext.SaveChangesAsync();
        return team;
    }

    public async Task<List<Team>> GetAllAsync()
    {
        return await DbContext.Teams.ToListAsync();
    }
}