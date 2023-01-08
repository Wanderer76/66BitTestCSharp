using System.Diagnostics;
using FootbalCatalog.ViewModels;
using FootballCatalog.Dto;
using Microsoft.AspNetCore.Mvc;
using FootballCatalog.Models;
using FootballCatalog.Service;

namespace FootballCatalog.Controllers;

public class FootballerController : Controller
{
    private readonly ILogger<FootballerController> _logger;
    private readonly ITeamService _teamService;
    private readonly IGenderService _genderService;
    private readonly ICountryService _countryService;
    private readonly IFootballerService _footballerService;

    public FootballerController(ILogger<FootballerController> logger, ITeamService teamService,
        ICountryService countryService, IGenderService genderService, IFootballerService footballerService)
    {
        _logger = logger;
        _teamService = teamService;
        _countryService = countryService;
        _genderService = genderService;
        _footballerService = footballerService;
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

    public async Task<IActionResult> FootballersList()
    {
        var t = new FootballersListViewModel
        {
            Footballers = (await _footballerService.GetDetailFootballersList())
        };
        return View(t);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFootballer(DetailFootballerDto detailFootballerDto)
    {
        if (ModelState.IsValid)
        {
            await _footballerService.CreateOrUpdateFootballer(detailFootballerDto);
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
        _logger.LogInformation("UPDATEEEE");
        return View("Index", t);
    }

    [Route("/Footballer/DeleteFootballer/{id:int}")]
    public async Task<IActionResult> DeleteFootballer(int id)
    {
        await _footballerService.DeleteFootballerById(id);
        return Redirect("/Footballer/FootballersList");
    }
}