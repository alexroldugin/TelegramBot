using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Domain.Commands.Strategies.Childs.List_All_Strategies.Childs.StrategyDynamicMenu.StopStrategy
{
    class StopStrategy: TelegramCommand
    {
        public StopStrategy(string strategyName):base(strategyName,strategyName){}
        public override string Name { get; set; } = ReservedStrings.StopStrategy;
        protected override string ParentName { get; set;} = ReservedStrings.Strategy;

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = KeyboardMarkup;
            await client.SendTextMessageAsync(chatId, "Тут должна быть важная информация",
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
