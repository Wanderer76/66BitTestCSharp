namespace FootballCatalog.Service;

public interface ICountryService
{
    Task<List<string>> GetCountriesNames();
}