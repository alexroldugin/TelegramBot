using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Commands.Current_Balance.Childs
{
    class ProfitAndLoss:TelegramCommand
    {
        public override string Name { get; } = "💰 Profit and loss";
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new []
                    {
                        new KeyboardButton(@"🔙 Back to 💰Current balance")
                    }
                }
            };
            await client.SendTextMessageAsync(chatId, "Something is Here",
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
