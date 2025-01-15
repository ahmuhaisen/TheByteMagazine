namespace TheByteMagazine.Domain.Entities;

public class RoleType : IEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool isUnique { get; set; }
}
