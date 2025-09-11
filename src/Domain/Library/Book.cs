namespace Domain.Library;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; private set; }
    public string Description { get; private set; } 
    
    public Guid AuthorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; protected set; }
    
    private Book(Guid id, string title, string description, Guid authorId, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Title = title;
        Description = description;
        AuthorId = authorId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Book New(Guid id, string title, string description, Guid authorId)
    {
        return new Book(id, title, description, authorId, DateTime.UtcNow, null);
    }
    
    public void UpdateDetails(string title, string description)
    {
        Title = title;
        Description = description;

        UpdatedAt = DateTime.UtcNow;
    }
    
    
}