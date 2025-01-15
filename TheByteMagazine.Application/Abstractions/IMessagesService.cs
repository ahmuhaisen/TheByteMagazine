using TheByteMagazine.Application.DTOs;

namespace TheByteMagazine.Application.Abstractions;
public interface IMessagesService
{
    Task<IEnumerable<MessageDTO>> GetAllAsync();

    Task<int> CreateAsync(MessageDTO message);
}
