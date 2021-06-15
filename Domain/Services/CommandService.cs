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
            _commands = GetAllCommands();
        }

        public List<TelegramCommand> Get() => _commands;

        private List<TelegramCommand> GetAllCommands()
        {
            var list = new List<TelegramCommand>();
            GetAllChildsOfCommand(new Start(), list);
            return list;
        }

        private void GetAllChildsOfCommand(TelegramCommandWithChilds command, List<TelegramCommand> listOfCommands)
        {
            listOfCommands.Add(command);
            foreach (var childCommand in command.Childs)
            {
                if (childCommand is TelegramCommandWithChilds commandWithChilds)
                {
                    GetAllChildsOfCommand(commandWithChilds, listOfCommands);
                }
                else
                {
                    listOfCommands.Add(childCommand);
                }
            }
        }
    }
}