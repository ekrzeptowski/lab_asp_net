using System.ComponentModel.DataAnnotations;

namespace lab3_app.Models
{
    public enum Priority
    {
        [Display(Name = "Niski")]Low,
        [Display(Name = "Normalny")]Normal,
        [Display(Name = "Wysoki")] High,
        [Display(Name = "Pilny")] Urgent
    }
}
