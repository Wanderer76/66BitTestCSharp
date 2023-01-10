using FootballCatalog.Repository;

namespace FootballCatalog.Service;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }


    public async Task<List<string>> GetCountriesNames()
    {
        var countries = await _countryRepository.GetAllAsync();
        return countries
            .Select(country => country.Name)
            .ToList();
    }
}