using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using FootballCatalog.Models;

namespace FootballCatalog.Dto;

public class DetailFootballerDto
{
    public int? Id { get; set; }
    
    [Display(Name = "Введите имя")]
    [Required(ErrorMessage = "Вам нужно ввести имя")]
    [MinLength(1, ErrorMessage = "Имя должно содержать более одного символа")]
    public string Name { get; set; }

    [Display(Name = "Введите фамилию")]
    [Required(ErrorMessage = "Вам нужно ввести фамилию")]
    [MinLength(3, ErrorMessage = "Фамилия должно содержать более трех символов")]
    public string Surname { get; set; }

    [Display(Name = "Введите дату рождения")]
    [Required(ErrorMessage = "Вам нужно ввести дату рождения")]
    [DataType(DataType.Date, ErrorMessage = "Вам нужно ввести дату рождения")]
    [NotNull]
    public DateTime? Birthdate { get; set; }

    [Display(Name = "Выберите пол")] public string Gender { get; set; }

    [Required(ErrorMessage = "Введите для создания/Выберите название команды")]
    [Display(Name = "Введите для создания/Выберите название команды")]
    [MinLength(2, ErrorMessage = "Название команды должно быть длинее двух символов")]
    public string Team { get; set; }

    [Display(Name = "Выберите страну")]
    [MinLength(2, ErrorMessage = "Название страны должно быть длинее двух символов")]

    public string Country { get; set; }


    public DetailFootballerDto(){}
    
    public DetailFootballerDto(Footballer footballer)
    {
        Id = footballer.Id;
        Name = footballer.Name;
        Surname = footballer.Surname;
        Birthdate = new DateTime(footballer.Birthdate.Year,footballer.Birthdate.Month,footballer.Birthdate.Day);
        Country = footballer.Country.Name;
        Gender = footballer.Gender.Name;
        Team = footballer.Team.Name;

    }
}