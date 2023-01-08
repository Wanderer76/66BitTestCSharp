using FootballCatalog.Models;
using FootballCatalog.Repository;
using FootballCatalog.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
        .LogTo(
            Console.WriteLine,
            LogLevel.Information));


builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IFootballerService, FootballerService>();

builder.Services.AddScoped<IFootballerRepository, FootballerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

using var db = new ApplicationDbContext();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Footballer}/{action=Index}/{id?}");

app.Run();