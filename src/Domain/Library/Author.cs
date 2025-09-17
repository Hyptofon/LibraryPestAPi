namespace Domain.Library;

public class Author
{
    public Guid Id { get; }
    public string Name { get; private set; }

    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }   // зробив публічний геттер

    private Author(Guid id, string name, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsDeleted = false;
    }

    public static Author New(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ім'я не може бути порожнім.", nameof(name));

        return new Author(id, name, DateTime.UtcNow, null);
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ім'я не може бути порожнім.", nameof(name));

        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}