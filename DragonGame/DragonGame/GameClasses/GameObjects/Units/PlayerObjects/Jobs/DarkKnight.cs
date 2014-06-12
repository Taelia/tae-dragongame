using DragonGame.GameClasses.AttackClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses.Jobs
{
    public class DarkKnight : BaseJob
    {
        public override string Name { get { return "DRK"; } }

        public DarkKnight(Player player) : base(player)
        {
            _Sprites.Add("Idle", new AnimatedSprite(GameLoop.Sprites["DarkKnight"], 1));
            _Sprites.Add("Walk", new AnimatedSprite(GameLoop.Sprites["DarkKnight-Walk"], 2));
            _Sprites.Add("AttackL", new AnimatedSprite(GameLoop.Sprites["DarkKnight-AttackL"], 2));
            _Sprites.Add("AttackR", new AnimatedSprite(GameLoop.Sprites["DarkKnight-AttackR"], 2));
            _Sprites.Add("Dead", new AnimatedSprite(GameLoop.Sprites["DarkKnight-Dead"], 1));
            _Sprites.Add("Hit", new AnimatedSprite(GameLoop.Sprites["DarkKnight-Hit"], 1));
            _Sprites.Add("Wounded", new AnimatedSprite(GameLoop.Sprites["DarkKnight-Wounded"], 1));
            _Sprites.Add("Victory", new AnimatedSprite(GameLoop.Sprites["DarkKnight-Victory"], 2));
        }

        public override BaseAttack Attack()
        {
            return new MeleeAttack(this);
        }
    }
}
