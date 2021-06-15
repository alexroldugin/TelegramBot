using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Commands.Heartbeat.Childs;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands.Heartbeat
{
    public class Heartbeat : TelegramCommandWithChilds
    {
        public override string Name { get;set;} = ReservedStrings.Heartbeat;
        protected override string ParentName { get; set;} = ReservedStrings.Start;

        public override List<TelegramCommand> Childs { get; set; } =
            new List<TelegramCommand>() {new ShowState(), new ToggleState()};

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = KeyboardMarkup;
            
            await client.SendTextMessageAsync(chatId, "💓 Heartbeat",
                parseMode: ParseMode.Html, replyMarkup: keyBoard);
        }

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }
    }
}