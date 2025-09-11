namespace Domain.Library;

public class Author
{
    public Guid Id { get; }
    public string Name { get; private set; }
    
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; private set; }

    private Author(Guid id, string name,  DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Author New(Guid id, string name)
    {
        return new Author(id, name, DateTime.UtcNow, null);
    }

    public void Rename(string name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }
}