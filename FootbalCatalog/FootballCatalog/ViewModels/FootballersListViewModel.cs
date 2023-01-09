using FootballCatalog.Dto;

namespace FootballCatalog.ViewModels;

public class FootballersListViewModel
{
    public IEnumerable<DetailFootballerDto> Footballers { get; set; } 
}