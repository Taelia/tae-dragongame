using DragonGame.GameClasses.AttackClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses.Jobs
{
    public class Summoner : BaseJob
    {
        public override string Name { get { return "SMN"; } }

        public Summoner(Player player) : base(player)
        {
            _Sprites.Add("Idle", new AnimatedSprite(GameLoop.Sprites["Summoner"], 1));
            _Sprites.Add("Walk", new AnimatedSprite(GameLoop.Sprites["Summoner-Walk"], 2));
            _Sprites.Add("AttackL", new AnimatedSprite(GameLoop.Sprites["Summoner-AttackL"], 2));
            _Sprites.Add("AttackR", new AnimatedSprite(GameLoop.Sprites["Summoner-AttackR"], 2));
            _Sprites.Add("Dead", new AnimatedSprite(GameLoop.Sprites["Summoner-Dead"], 1));
            _Sprites.Add("Hit", new AnimatedSprite(GameLoop.Sprites["Summoner-Hit"], 1));
            _Sprites.Add("Wounded", new AnimatedSprite(GameLoop.Sprites["Summoner-Wounded"], 1));
            _Sprites.Add("Victory", new AnimatedSprite(GameLoop.Sprites["Summoner-Victory"], 2));
        }

        public override BaseAttack Attack()
        {
            return new MeleeAttack(this);
        }
    }
}
