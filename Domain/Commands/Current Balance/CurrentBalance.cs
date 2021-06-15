using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Commands.Current_Balance.Childs;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands.Current_Balance
{
    public class CurrentBalance: TelegramCommandWithChilds
    {
        public override string Name { get; } = ReservedStrings.CurrentBalance;
        protected override string ParentName { get; } = ReservedStrings.Start;

        public override List<TelegramCommand> Childs { get; set; } = new List<TelegramCommand>()
            {new CheckBalance(), new ProfitAndLoss(), new DetailedProfitAndLoss()};

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = KeyboardMarkup;
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