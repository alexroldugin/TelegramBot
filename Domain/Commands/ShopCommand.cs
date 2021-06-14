using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands
{
    public class ShopCommand: TelegramCommand
    {
        public override string Name { get; } = "💓 Heartbeat";
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("❤️ Show state")
                    },
                    new[]
                    {
                        new KeyboardButton("💟 Toggle state")
                    }
                }
            };
            await client.SendTextMessageAsync(chatId, "💓 Heartbeat",
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