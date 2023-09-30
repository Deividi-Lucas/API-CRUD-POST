using System.ComponentModel.DataAnnotations;

namespace dotnet_api.Models;

public class ToDo
{
  public int Id { get; set; }

  [Required]
  public string? Title { get; set; }

  [Required]
  public string? Description { get; set; }

  [Required]
  public DateTime DatePost { get; set; }

  [Required]
  public bool IsDelete { get; set; }
}