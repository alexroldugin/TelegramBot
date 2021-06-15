using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands
{
    public class CurrentBalance: TelegramCommand
    {
        public override string Name { get; } = "💰 Current balance";
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("⚖️ Check balance")
                    },
                    new[]
                    {
                        new KeyboardButton("💰 Profit and loss")
                    },
                    new []
                    {
                        new KeyboardButton("💹 Detailed profit and loss")
                    }
                    ,new []
                    {
                        new KeyboardButton(@"🔙 Back to /start")
                    }
                }
            };
            await client.SendTextMessageAsync(chatId, "💰 Current balance",
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