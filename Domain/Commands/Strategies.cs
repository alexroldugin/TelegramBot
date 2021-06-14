using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands
{
    public class Strategies:TelegramCommand
    {
        public override string Name { get; } = "🎲 Strategies";
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("📝 List all strategies")
                    },
                    new[]
                    {
                        new KeyboardButton("🛑 Stop all strategiesк")
                    },
                    new []
                    {
                        new KeyboardButton("🚀 Start all strategies")
                    }
                }
            };
            await client.SendTextMessageAsync(chatId, "🎲 Strategies",
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