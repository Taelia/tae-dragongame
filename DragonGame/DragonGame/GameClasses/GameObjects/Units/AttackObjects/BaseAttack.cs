using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses.AttackClasses
{
    public enum AttackTarget { DRAGON, FRONTROW, BACKROW, ALL };

    public abstract class BaseAttack : IAnimatable
    {
        public AttackTarget Target;
        
        protected BaseJob _Job;

        protected AnimatedSprite _Sprite;
        protected Vector2 _Position;

        private bool _animating = true;
        public bool Animating { get { return _animating; } set { _animating = value; } }

        public int Damage;

        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch, Vector2 basePosition)
        {
            if (_Sprite != null)
                _Sprite.Draw(spriteBatch, basePosition + _Position, Color.White);
        }
    }
}
