using DragonGame;
using Meebey.SmartIrc4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeLib.Irc;

namespace Tomestone.Chatting
{
    public partial class DragonChat
    {
        public void AdminCommands(Channel channel, IrcUser from, string message, string command)
        {
            if (channel.Name != Main.chatMods) return;

            //Example method
            /*
        switch (command)
        {
                
        case "@info":
            _parse.ParseInfo(channel, message);
            break;
        case "@delete":
            _parse.ParseDelete(channel, message);
            break;
                 
        }
             * * */
        }

        public void UserCommands(Channel channel, IrcUser from, string message, string command)
        {
            if (channel.Name != Main.chatMain) return;

            //Example method
            /*
        switch (command)
        {
                
        case "!teach":
            _parse.ParseTeach(channel, from, message);
            break;
        case "!quote":
            _parse.ParseQuote(channel, message);
            break;
            
        }
             * */
        }

        public void DefaultCommands(Channel channel, IrcUser from, string message, string command)
        {
            _chat.OnMessage(from.Nick, message);
        }
    }
}
