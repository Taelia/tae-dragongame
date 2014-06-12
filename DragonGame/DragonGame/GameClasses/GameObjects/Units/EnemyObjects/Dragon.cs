using DragonGame.GameClasses.AttackClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DragonGame.GameClasses
{
    public class Dragon
    {
        public Stat HP;

        public Dragon()
        {
            HP = new Stat("HP", 0, 9999);
            HP.Value = 4500;
        }

        public BaseAttack Attack()
        {
            return new DragonAttack();
        }

        public BaseAttack Ability()
        {
            return new DragonAttack();
        }

        public void Defend(BaseAttack attack)
        {
            HP.ChangeValue(-1 * attack.Damage);
        }

        public void Update(GameTime gameTime)
        {
            HP.Update(gameTime);

            if (HP.Value == 0) HP.Value = HP.Max;
        }
    }
}
