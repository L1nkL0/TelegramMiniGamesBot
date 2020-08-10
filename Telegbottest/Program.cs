using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using io = System.IO;

namespace Telegbottest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TelegramBotClient bot = new TelegramBotClient(io.File.ReadAllText("D:/token/testlobot.txt"));

            Dictionary<long, int> db = new Dictionary<long, int>(); 


            Console.WriteLine($"{bot.GetMeAsync().Result.Username}"); //вывод имени бота
            
            

            bot.OnMessage += (q, arg) =>        //отправляет сообщение с тем что написал пользователь
            {

                #region переменные
                var chatid = arg.Message.Chat.Id;      //переменные содержащие функции бота в сокращенном варианте
                var username = arg.Message.Chat.Username;
                var firstname = arg.Message.Chat.FirstName;
                var messagetext = arg.Message.Text;
                var messageid = arg.Message.MessageId;
                bool x0 = false;

                #endregion

                //text = messagetext;
                //Console.WriteLine(text);
                //bot.SendTextMessageAsync(chatId: chatid,
                //    text: $"{chatid}: {messagetext}",
                //    replyToMessageId: messageid);

                Console.WriteLine($"{username} - {firstname}: {messagetext}");
               
                #region старт
                if (messagetext.ToLower() == "/start")
                {
                    bot.SendTextMessageAsync(chatId: chatid,
                        text: $"Добро пожаловать, {firstname}\n мои команды пока особо не работают но все равно держи");
                    bot.SendTextMessageAsync(chatId: chatid,
                        text: $"/start\n/xo");
                    bot.SendTextMessageAsync(chatId: chatid,
                        text: "Хотите со мной сыграть?");
                }
                #endregion

                #region запуск игры в крестики нолики
                if (messagetext == "/xo")
                {
                    x0 = true;
                    bot.SendTextMessageAsync(chatId: chatid, text: "вы \"крестик\" или \"нолик\"?");
                }
                #endregion

                #region игра в крестики нолики
                if (x0)
                {
                    if (messagetext.ToLower() == "/нолик")
                    {
                        
                        bot.SendTextMessageAsync(chatId: chatid, text: "Хорошо, тогда я \"x\"");
                        bot.SendTextMessageAsync(chatId: chatid, text: "1 2 3\n4 5 6\n7 8 9");
                        bot.SendTextMessageAsync(chatId: chatid, text: "отправьте число куда хотите поставить");

                    }
                    if (messagetext.ToLower() == "крести")
                    {

                        bot.SendTextMessageAsync(chatId: chatid, text: "Хорошо, тогда я \"0\"");
                        bot.SendTextMessageAsync(chatId: chatid, text: "1 2 3\n4 5 6\n7 8 9");
                        bot.SendTextMessageAsync(chatId: chatid, text: "отправьте число куда хотите поставить");
                    }
                }
                #endregion






                //Console.WriteLine($"{firstname}: {messagetext}");
                //bot.SendTextMessageAsync(chatId: arg.Message.Chat.Id,
                //    text: "Спасибо",
                //    replyToMessageId: messageid);



            };
            
            bot.StartReceiving();
            Console.ReadLine();

        }
    }
}
