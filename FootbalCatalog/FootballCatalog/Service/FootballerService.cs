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

    public async Task<Footballer> CreateOrUpdateFootballer(DetailFootballerDto detailFootballerDto)
    {
        if (detailFootballerDto.Id == null)
        {
            var result = new Footballer
            {
                Name = detailFootballerDto.Name,
                Surname = detailFootballerDto.Surname,
                Birthdate = DateOnly.FromDateTime(detailFootballerDto.Birthdate.Value),
                Gender = await _genderRepository.GetGenderByNameAsync(detailFootballerDto.Gender),
                Country = await _countryRepository.GetCountryByNameAsync(detailFootballerDto.Country),
                Team = await _teamService.GetTeamOrCreate(detailFootballerDto.Team)
            };
            return await _footballerRepository.CreateFootballerAsync(result);
        }

        var player = await _footballerRepository.FindFootballerByIdAsync(detailFootballerDto.Id.Value);
        player.Name = detailFootballerDto.Name;
        player.Surname = detailFootballerDto.Surname;
        player.Birthdate = DateOnly.FromDateTime(detailFootballerDto.Birthdate.Value);
        player.Gender = await _genderRepository.GetGenderByNameAsync(detailFootballerDto.Gender);
        player.Country = await _countryRepository.GetCountryByNameAsync(detailFootballerDto.Country);
        player.Team = await _teamService.GetTeamOrCreate(detailFootballerDto.Team);
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