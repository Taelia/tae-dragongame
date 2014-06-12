using DragonGame.GameClasses.AttackClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses.Jobs
{
    public class Dragoon : BaseJob
    {
        public override string Name { get { return "DRG"; } }

        public Dragoon(Player player) : base(player)
        {
            _Sprites.Add("Idle", new AnimatedSprite(GameLoop.Sprites["Dragoon"], 1));
            _Sprites.Add("Walk", new AnimatedSprite(GameLoop.Sprites["Dragoon-Walk"], 2));
            _Sprites.Add("AttackL", new AnimatedSprite(GameLoop.Sprites["Dragoon-AttackL"], 2));
            _Sprites.Add("AttackR", new AnimatedSprite(GameLoop.Sprites["Dragoon-AttackR"], 2));
            _Sprites.Add("Dead", new AnimatedSprite(GameLoop.Sprites["Dragoon-Dead"], 1));
            _Sprites.Add("Hit", new AnimatedSprite(GameLoop.Sprites["Dragoon-Hit"], 1));
            _Sprites.Add("Wounded", new AnimatedSprite(GameLoop.Sprites["Dragoon-Wounded"], 1));
            _Sprites.Add("Victory", new AnimatedSprite(GameLoop.Sprites["Dragoon-Victory"], 2));
        }

        public override BaseAttack Attack()
        {
            return new MeleeAttack(this);
        }
    }
}
