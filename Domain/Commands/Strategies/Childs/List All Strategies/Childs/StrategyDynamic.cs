using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Domain.Commands.Strategies.Childs.List_All_Strategies.Childs
{
    public class StrategyDynamic: TelegramCommandWithChilds
    {
        public StrategyDynamic(string nameOfStrategy) : base(nameOfStrategy)
        {
        }
        public override string Name { get;set; } = ReservedStrings.Strategy;
        protected override string ParentName { get;set; } = ReservedStrings.ListAllStrategies;
        public override List<TelegramCommand> Childs { get; set; } = new List<TelegramCommand>();


        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = KeyboardMarkup;
            await client.SendTextMessageAsync(chatId, "Что-то тут должно быть, наверняка",
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