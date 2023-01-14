using FootballCatalog.Dto;
using FootballCatalog.Models;

namespace FootballCatalog.Service;

public interface IFootballerService
{
    Task<Footballer> CreateFootballer(DetailFootballerDto detailFootballerDto);
    Task<Footballer> UpdateFootballer(DetailFootballerDto detailFootballerDto);
    Task<List<DetailFootballerDto>> GetDetailFootballersList();
    Task<Footballer> GetFootballerById(int id);
    Task DeleteFootballerById(int id);
}