using DragonGame.GameClasses.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeLib.Db;

namespace DragonGame.GameClasses
{
    public class DragonDatabase
    {
        public Player LoadPlayer(string name)
        {
            var player = new Player(name);

            var parms = new Dictionary<string, string>();
            parms.Add("@User", name);

            var results = Main.Db.Query("SELECT * FROM dragon WHERE user = '@User'", parms);
            if (results.Rows.Count == 0)
            {
                var data = new Dictionary<string, string>();
                data.Add("user", name);
                Main.Db.Insert("Dragon", data);
                return player;
            }

            var result = results.Rows[0];

            int level = int.Parse(result["level"].ToString());
            int exp = int.Parse(result["exp"].ToString());
            string currentJob = result["currentJob"].ToString();
            int karma = int.Parse(result["karma"].ToString());
            DateTime lastSeen = DateTime.Parse(result["lastSeen"].ToString());

            player.Initialize(level, exp, currentJob, lastSeen);

            return player;
        }

        public void SavePlayer(Player player)
        {
            var data = new Dictionary<string, string>();
            data.Add("level", player.Level.Value.ToString());
            data.Add("exp", player.Exp.Value.ToString());
            data.Add("currentJob", player.Job.Name);
            data.Add("karma", player.Karma.Value.ToString());
            data.Add("lastSeen", player.LastSeen.ToString("s"));

            var parms = new Dictionary<string, string>();
            parms.Add("@User", player.Name);
            Main.Db.Update("dragon", data, "user = '@User'", parms);
        }

    }
}
