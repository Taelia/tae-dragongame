using TomeLib.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TomeLib.Irc;
using Tomestone.Chatting;
using Meebey.SmartIrc4net;

namespace Tomestone.Commands
{
    public class DefaultCommands
    {
        private DragonChat _chat;

        public DefaultCommands(DragonChat chat)
        {
            _chat = chat;
        }

        //Example method
        /*
        public void Reply(Channel channel, IrcUser from, string message)
        {
            var search = message;

            var results = _database.SearchBy(TableType.REPLY, "trigger", search);
            if (results == null) return;

            var obj = PickRandomReply(results);
            if (obj == null) return;

            _chat.SentMessages.Add(obj);

            //Replace wildcards with their corresponing replacements.
            var reply = obj.Message.Replace("%who", from.Nick);

            //Finally, send the message.
            _chat.SendMessage(channel.Name, reply);
            _chat.UpdateUser("tomestone", reply);
        }
         * */
    }
}