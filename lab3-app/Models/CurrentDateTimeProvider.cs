
namespace lab3_app.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentTime => DateTime.Now;
    }
}
