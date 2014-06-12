using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses
{
    public class IdleAnimation : IAnimatable
    {
        protected BaseJob _Job;

        protected AnimatedSprite _Sprite;

        public bool Animating { get; set; }

        public IdleAnimation(BaseJob job)
        {
            _Job = job;
        }

        public void Update(GameTime gameTime)
        {
            _Sprite = _Job._Sprites["Idle"];
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 basePosition)
        {
            if (_Sprite != null)
                _Sprite.Draw(spriteBatch, basePosition, Color.White);
        }
    }
}
