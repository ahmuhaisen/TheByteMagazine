using AutoMapper;
using TheByteMagazine.Application.Abstractions;
using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Domain.Entities;
using TheByteMagazine.Infrastructure.Abstractions;

namespace TheByteMagazine.Application.Services;


public class MessagesService(IMessagesRepository _repo, IMapper _mapper) : IMessagesService
{
    public async Task<IEnumerable<MessageDTO>> GetAllAsync()
    {
        var allMessages = await _repo.GetAllAsync();

        if (allMessages is null)
            return Enumerable.Empty<MessageDTO>();

        var result = _mapper.Map<IEnumerable<MessageDTO>>(allMessages);

        return result;
    }


    public async Task<int> CreateAsync(MessageDTO message)
    {
        if (message is null)
            return await Task.FromResult(-1);

        var messageToCreate = _mapper.Map<Message>(message);

        return await _repo.CreateAsync(messageToCreate);
    }
}
