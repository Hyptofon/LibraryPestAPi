using Domain.Library;

namespace Application.Common.Interfaces
{
    public interface IAuthorService
    {
        Author CreateAuthor(Guid id, string name);
        Author? UpdateAuthor(Guid id, string name);   // може повернути null, якщо не знайдено
        bool DeleteAuthor(Guid id);
        Author? GetAuthorById(Guid id);
        IReadOnlyList<Author> GetAuthors();           // повертає тільки не видалених авторів
    }
}