using FootballCatalog.Service;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FootballCatalog.Hubs;

public class FootballersHub : Hub
{
    private readonly IFootballerService _footballerService;

    public FootballersHub(IFootballerService footballerService)
    {
        _footballerService = footballerService;
    }

    public async Task SendFootballers()
    {
        var t = await _footballerService.GetDetailFootballersList();
        var serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateFormatString = "dd.MM.yyyy"
        };
        await Clients.All.SendAsync("show_data", JsonConvert.SerializeObject(t,serializerSettings));
    }
}