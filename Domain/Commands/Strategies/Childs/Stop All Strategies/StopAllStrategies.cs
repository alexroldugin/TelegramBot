using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands.Strategies.Childs.Stop_All_Strategies
{
    class StopAllStrategies:TelegramCommand
    {
        public override string Name { get; } = "🛑 Stop all strategies";
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new []
                    {
                        new KeyboardButton(@"🔙 Back to 🎲 Strategies")
                    }
                }
            };
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
