using System.Collections.Generic;
using Domain.Abstractions;
using Domain.Commands;
using Domain.Commands.Current_Balance;
using Domain.Commands.Heartbeat;
using Domain.Commands.LicenseInfo;
using Domain.Commands.Strategies;

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