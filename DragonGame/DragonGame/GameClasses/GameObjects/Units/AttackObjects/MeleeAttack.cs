using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses.AttackClasses
{
    public class MeleeAttack : BaseAttack
    {
        private int stage = 0;

        public MeleeAttack(BaseJob job)
        {
            _Job = job;

            Damage = 100;
            Target = AttackTarget.DRAGON;
        }

        public override void Update(GameTime gameTime)
        {
            if (!Animating) return;

            switch (stage)
            {
                case 0:
                    _Sprite = _Job._Sprites["AttackL"];
                    stage++; break;
                case 1:
                    if (_Position.X > -32) { _Position.X--; _Sprite.Update(gameTime); }
                    else { stage++; } break;
                case 2:
                    _Sprite = _Job._Sprites["Walk"];
                    stage++; break;
                case 3:
                    if (_Position.X < 0) { _Position.X++; _Sprite.Update(gameTime); }
                    else { Animating = false; } break;
            }
        }
    }
}
