using DragonGame.GameClasses.AttackClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses.Jobs
{
    public class WhiteMage : BaseJob
    {
        public override string Name { get { return "WHM"; } }

        public WhiteMage(Player player) : base(player) {
            _Sprites.Add("Idle", new AnimatedSprite(GameLoop.Sprites["WhiteMage"], 1));
            _Sprites.Add("Walk", new AnimatedSprite(GameLoop.Sprites["WhiteMage-Walk"], 2));
            _Sprites.Add("AttackL", new AnimatedSprite(GameLoop.Sprites["WhiteMage-AttackL"], 2));
            _Sprites.Add("AttackR", new AnimatedSprite(GameLoop.Sprites["WhiteMage-AttackR"], 2));
            _Sprites.Add("Dead", new AnimatedSprite(GameLoop.Sprites["WhiteMage-Dead"], 1));
            _Sprites.Add("Hit", new AnimatedSprite(GameLoop.Sprites["WhiteMage-Hit"], 1));
            _Sprites.Add("Wounded", new AnimatedSprite(GameLoop.Sprites["WhiteMage-Wounded"], 1));
            _Sprites.Add("Victory", new AnimatedSprite(GameLoop.Sprites["WhiteMage-Victory"], 2));
        }

        public override BaseAttack Attack()
        {
            return new MeleeAttack(this);
        }
    }
}
