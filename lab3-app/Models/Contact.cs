using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab3_app.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Podaj imię")]
        [StringLength(50, ErrorMessage = "Imię może zawierać maksymalnie 50 znaków")]
        public string Name { get; set; }

        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Podaj adres e-mail")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail")]
        public string Email { get; set; }

        [Display(Name = "Numer telefonu")]
        [Phone(ErrorMessage = "Podaj poprawny numer telefonu")]
        public string Phone { get; set; }

        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date, ErrorMessage = "Podaj poprawną datę")]
        public DateTime Birth { get; set; }

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }
    }
}
