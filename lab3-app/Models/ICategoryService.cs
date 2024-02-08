namespace lab3_app.Models;

public interface ICategoryService
{
    int Add(Category category);
    void Delete(int id);
    void Update(Category category);
    List<Category> FindAll();
    Category? FindById(int id);
}