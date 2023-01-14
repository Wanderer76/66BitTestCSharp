using FootballCatalog.Dto;
using FootballCatalog.Models;
using FootballCatalog.Repository;

namespace FootballCatalog.Service;

public class FootballerService : IFootballerService
{
    private readonly IFootballerRepository _footballerRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly ITeamService _teamService;

    public FootballerService(IFootballerRepository footballerRepository, IGenderRepository genderRepository,
        ICountryRepository countryRepository, ITeamService teamService)
    {
        _footballerRepository = footballerRepository;
        _genderRepository = genderRepository;
        _countryRepository = countryRepository;
        _teamService = teamService;
    }

    public async Task<Footballer> CreateFootballer(DetailFootballerDto detailFootballerDto)
    {
        var gender = await _genderRepository.GetGenderByNameAsync(detailFootballerDto.Gender);
        var country = await _countryRepository.GetCountryByNameAsync(detailFootballerDto.Country);
        var team = await _teamService.GetTeamOrCreate(detailFootballerDto.Team);


        var result = new Footballer
        {
            Name = detailFootballerDto.Name,
            Surname = detailFootballerDto.Surname,
            Birthdate = DateOnly.FromDateTime(detailFootballerDto.Birthdate.Value),
            Gender = gender,
            Country = country,
            Team = team
        };
        return await _footballerRepository.UpdateFootballerAsync(result);
    }


    public async Task<Footballer> UpdateFootballer(DetailFootballerDto detailFootballerDto)
    {
        var gender = await _genderRepository.GetGenderByNameAsync(detailFootballerDto.Gender);
        var country = await _countryRepository.GetCountryByNameAsync(detailFootballerDto.Country);
        var team = await _teamService.GetTeamOrCreate(detailFootballerDto.Team);
        var player = await _footballerRepository.FindFootballerByIdAsync(detailFootballerDto.Id.Value);
        player.Name = detailFootballerDto.Name;
        player.Surname = detailFootballerDto.Surname;
        player.Birthdate = DateOnly.FromDateTime(detailFootballerDto.Birthdate.Value);
        player.Gender = gender;
        player.Country = country;
        player.Team = team;
        return await _footballerRepository.UpdateFootballerAsync(player);
    }

    public async Task<List<DetailFootballerDto>> GetDetailFootballersList()
    {
        var footballers = await _footballerRepository.GetAllAsync();
        return footballers
            .Select(footballer => new DetailFootballerDto
            {
                Id = footballer.Id,
                Birthdate = footballer.Birthdate.ToDateTime(TimeOnly.MinValue),
                Country = footballer.Country.Name,
                Surname = footballer.Surname,
                Name = footballer.Name,
                Gender = footballer.Gender.Name,
                Team = footballer.Team.Name
            })
            .ToList();
    }

    public async Task<Footballer> GetFootballerById(int id)
    {
        return await _footballerRepository.FindFootballerByIdAsync(id);
    }

    public async Task DeleteFootballerById(int id)
    {
        await _footballerRepository.DeleteFootballerByIdAsync(id);
    }
}