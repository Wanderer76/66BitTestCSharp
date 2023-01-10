using FootballCatalog.Repository;

namespace FootballCatalog.Service;

public class GenderService : IGenderService
{
    private readonly IGenderRepository _genderRepository;

    public GenderService(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;
    }

    public async Task<List<string>> GetGenderNames()
    {
        var genders = await _genderRepository.GetAllAsync();
        return genders
            .Select(gender => gender.Name)
            .ToList();
    }
}