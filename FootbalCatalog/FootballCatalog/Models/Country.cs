using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballCatalog.Models;

[Table("Country")]
public class Country
{
    public static readonly string Russia = "Россия";
    public static readonly string Usa = "США";
    public static readonly string Italy = "Италия";

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Footballer> Footballers { get; set; }
}