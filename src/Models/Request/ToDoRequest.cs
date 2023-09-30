using System.ComponentModel.DataAnnotations;

namespace dotnet_api.Models;

public class ToDoRequest
{

  [Required]
  public string? Title { get; set; }

  [Required]
  public string? Description { get; set; }

}