using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Abstractions
{
    public abstract class TelegramCommand
    {
        protected TelegramCommand()
        {
            KeyboardMarkup = GenerateKeyboard();
        }
        public abstract string Name { get; }
        protected abstract string ParentName { get; }

        public abstract Task Execute(Message message, ITelegramBotClient client);

        public abstract bool Contains(Message message);
        protected ReplyKeyboardMarkup KeyboardMarkup { get; set; }

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