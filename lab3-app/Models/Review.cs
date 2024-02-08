using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lab3_app.Models;

public class Review
{
    [HiddenInput]
    public int Id { get; set; }
    
    [HiddenInput]
    public string UserId { get; set; }
    
    [Display(Name = "Komentarz")]
    [Required(ErrorMessage = "Podaj komentarz")]
    [StringLength(500, ErrorMessage = "Komentarz może zawierać maksymalnie 500 znaków")]
    public string Comment { get; set; }
    
    [Display(Name = "Ocena")]
    [Required(ErrorMessage = "Podaj ocenę")]
    [Range(1, 5, ErrorMessage = "Ocena musi być z zakresu od 1 do 5")]
    public int Rating { get; set; }
    
    [HiddenInput]
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    public IdentityUser User { get; set; }
}