using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Commands.Heartbeat.Childs;
using Domain.Commands.Strategies.Childs.List_All_Strategies.Childs;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands.Strategies.Childs.List_All_Strategies
{
    class ListAllStrategies:TelegramCommandWithChilds
    {
        public override string Name { get;set; } = ReservedStrings.ListAllStrategies;
        protected override string ParentName { get;set; } = ReservedStrings.Strategies;
        public override List<TelegramCommand> Childs { get; set; } = new List<TelegramCommand>();
    
        public ListAllStrategies()
        {
            //представим, что данные для этого динамического листа вытягиваются из базы данных
            var database = new List<string>() {"NeverGiveUp", "ShortPlay"};
            foreach (var elem in database)
            {
                // Childs.Add(new StrategyDynamic(ReservedStrings.Strategy + elem));
                Childs.Add(new StrategyDynamic(elem));
            }
        }

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
