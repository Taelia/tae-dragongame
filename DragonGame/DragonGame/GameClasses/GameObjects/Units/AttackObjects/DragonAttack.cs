using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses.AttackClasses
{
    public class DragonAttack : BaseAttack
    {
        public DragonAttack()
        {
            Damage = 100;
            Target = AttackTarget.FRONTROW;
        }

        public override void Update(GameTime gameTime)
        {
            return;
        }
    }
}
