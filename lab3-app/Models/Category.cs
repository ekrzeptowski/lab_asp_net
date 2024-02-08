using System.ComponentModel.DataAnnotations;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace lab3_app.Models;

public class Category
{
    [HiddenInput] public int Id { get; set; }

    [Display(Name = "Nazwa kategorii")]
    [Required(ErrorMessage = "Podaj nazwę kategorii")]
    [StringLength(50, ErrorMessage = "Nazwa kategorii może zawierać maksymalnie 50 znaków")]
    public string Name { get; set; }

    [Display(Name = "Opis")] public string? Description { get; set; }

    [ValidateNever]
    [Display(Name = "Produkty")] public ISet<ProductEntity> Products { get; set; }
}