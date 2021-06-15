using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Commands.Strategies.Childs.Stop_All_Strategies.Childs;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands.Strategies.Childs.Stop_All_Strategies
{
    class StopAllStrategies:TelegramCommandWithChilds
    {
        public override string Name { get; set;} = ReservedStrings.StopAllStrategies;
        protected override string ParentName { get; set;} = ReservedStrings.Strategies;

        public override List<TelegramCommand> Childs { get; set; } = new List<TelegramCommand>()
        {
            new JustStopAllStrategies(), new CancelAndStopAllStrategies(), new CancelJustLayBetsAndStopAllStrategies()
        };

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = KeyboardMarkup;
            await client.SendTextMessageAsync(chatId, "Something is here",
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
