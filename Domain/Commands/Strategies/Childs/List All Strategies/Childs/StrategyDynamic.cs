using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Commands.Strategies.Childs.List_All_Strategies.Childs.StrategyDynamicMenu;
using Domain.Commands.Strategies.Childs.List_All_Strategies.Childs.StrategyDynamicMenu.StopStrategy;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Domain.Commands.Strategies.Childs.List_All_Strategies.Childs
{
    public class StrategyDynamic : TelegramCommandWithChilds
    {
        public StrategyDynamic(string nameOfStrategy) : base(nameOfStrategy)
        {
            Childs = new List<TelegramCommand>()
            {
                new Summary(nameOfStrategy), new UnmatchedBets(nameOfStrategy), new MatchedBets(nameOfStrategy),
                new Statistics(nameOfStrategy), new Settings(nameOfStrategy), new Description(nameOfStrategy),
                new StopStrategy(nameOfStrategy)
            };
        }

        public override string Name { get; set; } = ReservedStrings.Strategy;
        protected override string ParentName { get; set; } = ReservedStrings.ListAllStrategies;
        public override List<TelegramCommand> Childs { get; set; }


        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = KeyboardMarkup;
            await client.SendTextMessageAsync(chatId, "Что-то тут должно быть, наверняка",
                parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }
    }
}