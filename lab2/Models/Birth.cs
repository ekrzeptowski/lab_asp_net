namespace lab2.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsValid()
        {
            return Name != null && BirthDate != null && BirthDate < DateTime.Now;
        }

        public int GetAge()
        {
            return DateTime.Now.Year - BirthDate.Year;
        }
    }
}
