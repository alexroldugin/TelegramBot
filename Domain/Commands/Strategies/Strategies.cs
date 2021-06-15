using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Commands.Strategies.Childs;
using Domain.Commands.Strategies.Childs.List_All_Strategies;
using Domain.Commands.Strategies.Childs.Stop_All_Strategies;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands.Strategies
{
    public class Strategies : TelegramCommandWithChilds
    {
        public override string Name { get; } = ReservedStrings.Strategies;
        protected override string ParentName { get; } = ReservedStrings.Start;

        public override List<TelegramCommand> Childs { get; set; } = new List<TelegramCommand>()
            {new ListAllStrategies(), new StartAllStrategies(), new StopAllStrategies()};

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = KeyboardMarkup;
            await client.SendTextMessageAsync(chatId, "Some text",
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