using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Commands.Current_Balance;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands
{
    public class Start : TelegramCommandWithChilds
    {
        public override string Name { get; set; } = ReservedStrings.Start;
        protected override string ParentName { get;set; } = "";

        public override List<TelegramCommand> Childs { get; set; } = new List<TelegramCommand>()
        {
            new CurrentBalance(), new LicenseInfo.LicenseInfo(), new Strategies.Strategies(), new Heartbeat.Heartbeat()
        };


        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, ITelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            var keyBoard = KeyboardMarkup;

            await botClient.SendTextMessageAsync(chatId, "Demo mode",
                parseMode: ParseMode.Html, null, false, false, 0, false, keyBoard);
        }
    }
}