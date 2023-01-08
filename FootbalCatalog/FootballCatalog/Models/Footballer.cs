using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballCatalog.Models;

[Table("Footballer")]
public class Footballer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly Birthdate { get; set; }
    public Gender Gender { get; set; }
    public Team Team { get; set; }
    public Country Country { get; set; }
}