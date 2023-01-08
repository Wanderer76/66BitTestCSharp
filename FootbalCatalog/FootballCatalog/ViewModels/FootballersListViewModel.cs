using FootballCatalog.Dto;

namespace FootbalCatalog.ViewModels;

public class FootballersListViewModel
{
    public ICollection<DetailFootballerDto> Footballers { get; set; } 
}