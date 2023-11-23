namespace lab3_app.Models
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentTime { get; }
    }
}
