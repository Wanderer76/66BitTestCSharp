﻿using FootballCatalog.Models;
using FootballCatalog.Repository;

namespace FootballCatalog.Service;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<Team> GetTeamOrCreate(string name)
    {
        var team = await _teamRepository.GetTeamByName(name);
        if (team == null)
        {
            return await _teamRepository.CreateTeam(new Team { Name = name });
        }

        return team;
    }

    public async Task<List<string>> GetAll()
    {
        var teams = await _teamRepository.GetAll();

        return teams
            .Select(team => team.Name)
            .ToList();
    }
}