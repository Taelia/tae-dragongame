using DragonGame.GameClasses;
using Meebey.SmartIrc4net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomeLib.Db;
using TomeLib.Irc;
using Tomestone.Chatting;

namespace DragonGame
{
    public class Main
    {
        private string botName = "Tomestone";
        private string botOauth = "oauth:npafwpg44j0a5iullxo2dt385n5jeco";
        public static string chatMain = "#taelia_";
        public static string chatMods = "#taelia_mods";

        public static Database Db { get { return Database.GetDatabase("dragon.db"); } }

        private GameLoop _game;
        private Irc _irc;

        public Main()
        {
            _game = new GameLoop(this);
            _irc = new Irc(botName, botOauth, new string[] { chatMain, chatMods }, new DragonChat(this));

            _game.Run();
        }

        public void OnMessage(string from, string message)
        {
            //_game.OnMessage(from, message);
        }
    }
}
