namespace Domain.Library;

public class Book
{
    public Guid Id { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid AuthorId { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    private Book(Guid id, string title, string description, Guid authorId,
        DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Title = title;
        Description = description;
        AuthorId = authorId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsDeleted = false;
    }

    public static Book New(Guid id, string title, string description, Guid authorId)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        return new Book(id, title, description, authorId, DateTime.UtcNow, null);
    }

    public void UpdateBook(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        Title = title;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}