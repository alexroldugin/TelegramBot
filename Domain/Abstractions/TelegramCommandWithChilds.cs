using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace Domain.Abstractions
{
    public abstract class TelegramCommandWithChilds : TelegramCommand
    {
        public abstract List<TelegramCommand> Childs { get; set; }
       
        protected TelegramCommandWithChilds() { }
        protected TelegramCommandWithChilds(string nameOfCommand) : base(nameOfCommand)
        {
            
        }

        protected sealed override ReplyKeyboardMarkup GenerateKeyboard()
        {
            var replyKeyboardMarkup = new ReplyKeyboardMarkup();
            replyKeyboardMarkup.Keyboard = GetKeyboardButtonFromChilds();
            return replyKeyboardMarkup;
        }

        //TODO тут наверняка придётся переписать на сетку 6 на 6
        private IEnumerable<IEnumerable<KeyboardButton>> GetKeyboardButtonFromChilds()
        {
            List<List<KeyboardButton>> keyboard = new List<List<KeyboardButton>>(6);
            for (var index = 0; index < Childs.Count; index++)
            {
                keyboard.Add(new List<KeyboardButton>(6) {new KeyboardButton(Childs[index].Name)});
            }

            if (!string.IsNullOrEmpty(ParentName))
                keyboard.Add(new List<KeyboardButton>(6)
                    {new KeyboardButton($"{ReservedStrings.BackTo}{ParentName}")});
            return keyboard;
        }
    }
}