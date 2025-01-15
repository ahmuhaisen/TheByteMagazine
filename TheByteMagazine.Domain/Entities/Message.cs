namespace TheByteMagazine.Domain.Entities;


public class Message : IEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Body { get; set; }
}
