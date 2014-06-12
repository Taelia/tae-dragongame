using TomeLib.Db;
using TomeLib.Irc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tomestone;
using Tomestone.Commands;
using Meebey.SmartIrc4net;
using DragonGame;

namespace Tomestone.Chatting
{
    public class ParseCommands
    {
        private IChat _chat;

        private AdminCommands adminCommands;
        private UserCommands userCommands;
        private DefaultCommands defaultCommands;

        public ParseCommands(DragonChat chat)
        {
            _chat = chat;

            adminCommands = new AdminCommands(chat);
            userCommands = new UserCommands(chat);
            defaultCommands = new DefaultCommands(chat);
        }

        //Example method
        /*
        public void ParseInfo(Channel channel, string message)
        {
            Match match = Regex.Match(message, "@info (.+)");

            if (match.Success)
            {
                string search = match.Groups[1].Value;

                adminCommands.ExecuteInfoCommand(search);

                return;
            }

            _chat.SendStatus(ChatMain.chatMods, "SYNTAX: '@info A' where A is a unique word from the sentence you want info on.");
        }
        */
    }
}
