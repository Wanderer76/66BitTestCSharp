using FootballCatalog.Hubs;
using FootballCatalog.ViewModels;
using FootballCatalog.Dto;
using Microsoft.AspNetCore.Mvc;
using FootballCatalog.Service;
using Microsoft.AspNetCore.SignalR;

namespace FootballCatalog.Controllers;

public class FootballerController : Controller
{
    private readonly IHubContext<FootballersHub> _hubContext;

    private readonly ITeamService _teamService;
    private readonly IGenderService _genderService;
    private readonly ICountryService _countryService;
    private readonly IFootballerService _footballerService;

    public FootballerController(ITeamService teamService,
        ICountryService countryService, IGenderService genderService, IFootballerService footballerService,
        IHubContext<FootballersHub> hubContext)
    {
        _teamService = teamService;
        _countryService = countryService;
        _genderService = genderService;
        _footballerService = footballerService;
        _hubContext = hubContext;
    }

    public async Task<IActionResult> Index()
    {
        var t = new FootballCreationViewModel
        {
            Teams = await _teamService.GetAll(),
            Countries = await _countryService.GetCountriesNames(),
            Genders = await _genderService.GetGenderNames()
        };
        return View(t);
    }

    public IActionResult FootballersList()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFootballer(DetailFootballerDto detailFootballerDto)
    {
        if (ModelState.IsValid)
        {
            if (detailFootballerDto.Id == null)
                await _footballerService.CreateFootballer(detailFootballerDto);
            else
                await _footballerService.UpdateFootballer(detailFootballerDto);

            await _hubContext.Clients.All.SendAsync("show_data",
                Json(await _footballerService.GetDetailFootballersList()));
            return Redirect("/Footballer/FootballersList");
        }

        var t = new FootballCreationViewModel
        {
            Teams = await _teamService.GetAll(),
            Countries = await _countryService.GetCountriesNames(),
            Genders = await _genderService.GetGenderNames(),
            DetailFootballerDto = detailFootballerDto
        };
        return View("Index", t);
    }

    [Route("/Footballer/UpdateFootballer/{id:int}")]
    public async Task<IActionResult> UpdateFootballer(int id)
    {
        var player = await _footballerService.GetFootballerById(id);
        var t = new FootballCreationViewModel
        {
            Teams = await _teamService.GetAll(),
            Countries = await _countryService.GetCountriesNames(),
            Genders = await _genderService.GetGenderNames(),
            DetailFootballerDto = new DetailFootballerDto(player)
        };
        return View("Index", t);
    }

    [Route("/Footballer/DeleteFootballer/{id:int}")]
    public async Task<IActionResult> DeleteFootballer(int id)
    {
        await _footballerService.DeleteFootballerById(id);
        return Redirect("/Footballer/FootballersList");
    }
}