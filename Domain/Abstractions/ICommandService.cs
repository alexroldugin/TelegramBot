using System.Collections.Generic;

namespace Domain.Abstractions
{
    public interface ICommandService
    {
        List<TelegramCommand> Get();
    }
}