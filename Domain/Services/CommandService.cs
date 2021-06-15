using System.Collections.Generic;
using Domain.Abstractions;
using Domain.Commands;

namespace Domain.Services
{
    public class CommandService: ICommandService
    {
        private readonly List<TelegramCommand> _commands;

        public CommandService()
        {
            _commands = new List<TelegramCommand>
            {
                new LicenseInfo(),
                new CurrentBalance(),
                new Strategies(),
                new Heartbeat(),
                new Start()
            };
        }

        public List<TelegramCommand> Get() => _commands;
    }
}