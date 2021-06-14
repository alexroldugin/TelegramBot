using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands
{
    public class LicenseInfo: TelegramCommand
    {
        public override string Name { get; } = "💡 License info";
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
           
            await client.SendTextMessageAsync(chatId, "💡 License info",
                parseMode: ParseMode.Markdown);
            await client.SendTextMessageAsync(chatId, "Какая-то важная информация",
                parseMode: ParseMode.Markdown);
        }

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }
    }
}