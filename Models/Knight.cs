using System.ComponentModel.DataAnnotations;

namespace Knights.Models
{
  public class Knight
  {
    public int Id { get; set; }
    [Required]
    public string KnightName { get; set; }
    public int CastleId { get; set; }
  }
}