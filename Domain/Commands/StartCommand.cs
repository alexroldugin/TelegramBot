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
                        new KeyboardButton("💰 Current balance")
                    },
                    new[]
                    {
                        new KeyboardButton("💡 License info")
                    },
                    new []
                    {
                        new KeyboardButton("🎲 Strategies")
                    },
                    new []
                    {
                        new KeyboardButton("💓 Heartbeat") 
                    }
                }
            };
          
            await botClient.SendTextMessageAsync(chatId, "Demo mode",
                parseMode: ParseMode.Html,null, false, false, 0, false, keyBoard);
        }
    }
}