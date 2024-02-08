namespace lab3_app.Models;

public interface IReviewService
{
    int Add(Review review);
    void Delete(int id);
    void Update(Review review);
    List<Review> FindAll();
    Review? FindById(int id);
}