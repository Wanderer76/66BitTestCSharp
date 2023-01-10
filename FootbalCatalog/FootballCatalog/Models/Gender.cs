using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballCatalog.Models;

[Table("Gender")]
public class Gender
{
    public static readonly string Male = "Мужской";
    public static readonly string Female = "Женский";

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Footballer> Footballers { get; set; }
}