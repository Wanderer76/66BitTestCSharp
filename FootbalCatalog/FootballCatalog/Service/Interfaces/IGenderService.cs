namespace FootballCatalog.Service;

public interface IGenderService
{
    Task<List<string>> GetGenderNames();
}