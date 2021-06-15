using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Abstractions
{
    public abstract class TelegramCommand
    {
        protected TelegramCommand() { }
        protected TelegramCommand(string commandName)
        {
            Name += commandName;
        }
        protected TelegramCommand(string commandName, string parentCommandName)
        {
            Name += commandName;
            ParentName += parentCommandName;
        }
        
        public abstract string Name { get;  set; }
        protected abstract string ParentName { get; set; }

        public abstract Task Execute(Message message, ITelegramBotClient client);

        public abstract bool Contains(Message message);
        protected virtual ReplyKeyboardMarkup KeyboardMarkup { get => GenerateKeyboard(); }

        protected virtual ReplyKeyboardMarkup GenerateKeyboard()
        {
            var keyboard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new []
                    {
                        new KeyboardButton(ReservedStrings.BackTo+ParentName)
                    }
                }
            };
            return keyboard;
        }
    }
}