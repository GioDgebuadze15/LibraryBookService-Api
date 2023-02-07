using System.ComponentModel.DataAnnotations;

namespace LibraryBookServiceApi.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Author { get; set; }
    
    [Required]
    public DateTime DateOfPublish { get; set; }
}