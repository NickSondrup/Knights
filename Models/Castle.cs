using System.ComponentModel.DataAnnotations;

namespace Knights.Models
{
  public class Castle
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Kingdom { get; set; }
  }
}