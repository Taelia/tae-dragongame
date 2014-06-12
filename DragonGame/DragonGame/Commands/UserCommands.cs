using TomeLib.Db;
using TomeLib.Irc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomestone.Chatting;

namespace Tomestone.Commands
{
    public class UserCommands
    {
        private DragonChat _chat;

        public UserCommands(DragonChat chat)
        {
            _chat = chat;
        }

        //Example method
        /*
        public void ExecuteHelpCommand(string subject)
        {
            switch (subject)
            {
                case "tome":
                    _chat.SendStatus(Main.chatMain, "http://www.simplively.com/blog/2014/02/02/tomestone/");
                    break;
                case "dragon":
                    _chat.SendStatus(Main.chatMain, "http://www.simplively.com/blog/2014/02/02/the-dragon-game/");
                    break;
            }
        }
         * */
    }
}
