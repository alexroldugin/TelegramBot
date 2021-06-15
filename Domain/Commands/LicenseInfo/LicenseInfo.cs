using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands.LicenseInfo
{
    public class LicenseInfo: TelegramCommand
    {
        public override string Name { get; } = ReservedStrings.LicenseInfo;
        protected override string ParentName { get; } = ReservedStrings.Start;

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = KeyboardMarkup;
            await client.SendTextMessageAsync(chatId, "Тут должна быть важная информация",
                parseMode: ParseMode.Markdown, replyMarkup:keyBoard);
        }

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }
    }
}