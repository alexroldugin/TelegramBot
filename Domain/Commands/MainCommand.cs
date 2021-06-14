using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands
{
    public class MainCommand: TelegramCommand
    {
        public override string Name { get; } = "\U0001F3E0 Главная";
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("\U0001F3E0 Главная")
                    },
                    new[]
                    {
                        new KeyboardButton("\U0001F451 Ранк")
                    },
                    new []
                    {
                        new KeyboardButton("\U0001F45C Магазин")
                    },
                    new []
                    {
                        new KeyboardButton("\U0001F4D6 Помощь") 
                    }
                }
            };
            await client.SendTextMessageAsync(chatId, "\U0001F3E0 Главная страница!",
                parseMode: ParseMode.Html, replyMarkup:keyBoard);
        }

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }
    }
}