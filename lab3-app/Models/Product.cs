using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3_app.Models
{
    public class Product
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Nazwa produktu")]
        [Required(ErrorMessage = "Podaj nazwę")]
        [StringLength(50, ErrorMessage = "Nazwa może zawierać maksymalnie 50 znaków")]
        public string Name { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Podaj cenę")]
        [Range(0, 1000000, ErrorMessage = "Podaj poprawną cenę")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        [Display(Name = "Producent")]
        [Required(ErrorMessage = "Podaj poprawnego producenta")]
        public string Producent { get; set; }

        [Display(Name = "Data produkcji")]
        [DataType(DataType.Date, ErrorMessage = "Podaj poprawną datę produkcji")]
        public DateTime ProductionDate { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; }
    }
}
