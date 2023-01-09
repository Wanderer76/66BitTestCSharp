using FootballCatalog.Dto;

namespace FootballCatalog.ViewModels;

public class FootballCreationViewModel
{
    public IEnumerable<string> Countries { get; set; } = new List<string>();
    public IEnumerable<string> Teams { get; set; } = new List<string>();
    public IEnumerable<string> Genders { get; set; } = new List<string>();
    public DetailFootballerDto DetailFootballerDto { get; set; }
}