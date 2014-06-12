using DragonGame.GameClasses.AttackClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses.Jobs
{
    public class Scholar : BaseJob
    {
        public override string Name { get { return "SCH"; } }

        public Scholar(Player player) : base(player)
        {
            _Sprites.Add("Idle", new AnimatedSprite(GameLoop.Sprites["Scholar"], 1));
            _Sprites.Add("Walk", new AnimatedSprite(GameLoop.Sprites["Scholar-Walk"], 2));
            _Sprites.Add("AttackL", new AnimatedSprite(GameLoop.Sprites["Scholar-AttackL"], 2));
            _Sprites.Add("AttackR", new AnimatedSprite(GameLoop.Sprites["Scholar-AttackR"], 2));
            _Sprites.Add("Dead", new AnimatedSprite(GameLoop.Sprites["Scholar-Dead"], 1));
            _Sprites.Add("Hit", new AnimatedSprite(GameLoop.Sprites["Scholar-Hit"], 1));
            _Sprites.Add("Wounded", new AnimatedSprite(GameLoop.Sprites["Scholar-Wounded"], 1));
            _Sprites.Add("Victory", new AnimatedSprite(GameLoop.Sprites["Scholar-Victory"], 2));
        }

        public override BaseAttack Attack()
        {
            return new MeleeAttack(this);
        }
    }
}
