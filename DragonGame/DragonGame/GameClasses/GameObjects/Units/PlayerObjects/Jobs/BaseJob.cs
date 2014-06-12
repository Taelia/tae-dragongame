using DragonGame.GameClasses.AttackClasses;
using DragonGame.GameClasses.Jobs;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses
{
    public abstract class BaseJob
    {
        protected Player _Player;

        public abstract string Name { get; }
        protected int _MaxHP = 1000;
        protected int _MaxMP = 100;

        public Dictionary<string, AnimatedSprite> _Sprites = new Dictionary<string, AnimatedSprite>();

        public BaseJob(Player player)
        {
            _Player = player;
        }

        public abstract BaseAttack Attack();
    }
}
