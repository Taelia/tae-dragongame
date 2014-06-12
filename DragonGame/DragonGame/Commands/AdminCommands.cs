using TomeLib.Irc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomestone.Chatting;

namespace Tomestone.Commands
{
    public class AdminCommands
    {
        private DragonChat _chat;

        public AdminCommands(DragonChat chat)
        {
            _chat = chat;
        }


        //Example method
        /*
        public void ExecuteInfoCommand(string search)
        {
            var obj = _chat.SentMessages.Search(search);
            if (obj != null)
            {
                var info = obj.Info();
                _chat.SendStatus(Main.chatMods, info);
                return;
            }
            _chat.SendStatus(Main.chatMods, "Message not found.");
        }
        */
    }
}
