using DragonGame.GameClasses;
using Meebey.SmartIrc4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomeLib.Irc;

namespace DragonGame
{
    public partial class GameLoop : Microsoft.Xna.Framework.Game
    {
        private DragonDatabase _db = new DragonDatabase();

        private Dictionary<string, Player> _players = new Dictionary<string, Player>();
        private Dictionary<Player, DateTime> _expDictionary = new Dictionary<Player, DateTime>();
        private BattleScreen _battle = new BattleScreen();

        public void OnMessage(string from, string message)
        {
            //Make sure that the player is loaded in from the database
            if (!_players.ContainsKey(from))
                _players[from] = _db.LoadPlayer(from);

            RewardExperience(_players[from]);

            if (message.Contains("Kappa") ||
                message.Contains("Kippa") ||
                message.Contains("Keepo"))
                PunishPlayerKarma(_players[from]);

            _battle.InitiateFight(_players[from], message);
        }

        private void TickPer30Minutes()
        {
            if (Irc.Client.GetChannel(Main.chatMain) != null)
                foreach (ChannelUser user in Irc.Client.GetChannel(Main.chatMain).Users.Values)
                {
                    if (_players.ContainsKey(user.Nick))
                        _players[user.Nick] = _db.LoadPlayer(user.Nick);

                    var player = _players[user.Nick];

                    player.Karma.Value++;
                    _db.SavePlayer(player);
                }
        }

        private void RewardExperience(Player player)
        {
            //Two hours added to make up for the stream starting two hours early.
            if ((DateTime.Now + TimeSpan.FromHours(2)).Date != (player.LastSeen + TimeSpan.FromHours(2)).Date)
            {
                //Less than 200 will slow down leveling. 1000 is maximum, five times normal.
                double multiplier = player.Karma.Value / 200;

                //Player gets one level worth of experience, times karma multiplier.
                var totalExp = player.Exp.Value + (1000 * multiplier);

                var addedExp = (int)totalExp % 1000;
                var addedLevels = (int)Math.Floor(totalExp / 1000);

                if (player.Level.Value == 99 && addedLevels > 0)
                    player.Exp.Value = 999;
                else
                {
                    player.Level.Value += addedLevels;
                    player.Exp.Value = (int)totalExp % 1000;
                }

                player.LastSeen = DateTime.Now + TimeSpan.FromHours(2);
                _db.SavePlayer(player);
            }
        }

        private void PunishPlayerKarma(Player player)
        {
            player.Karma.Value -= 2;
        }
    }
}
