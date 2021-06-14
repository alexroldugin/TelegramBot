using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands
{
    public class StartCommand : TelegramCommand
    {
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, ITelegramBotClient botClient)
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
          
            await botClient.SendTextMessageAsync(chatId, "Привет! Тебе присвоено звание Intern! Чтоб достичь больших " +
                                                         "успехов, тебе необходимо накопить определенное количество монет(К-от слова контрибуций)! Дерзай!",
                parseMode: ParseMode.Html,null, false, false, 0, false, keyBoard);
        }
    }
}