namespace Api.Dtos;

public record AuthorDto(Guid Id, string? Name, DateTime CreatedAt, DateTime? UpdatedAt)
{
    public static AuthorDto FromDomainModel(Domain.Library.Author author)
        => new(author.Id, author.Name, author.CreatedAt, author.UpdatedAt);
}

public record CreateAuthorDto(string Name);