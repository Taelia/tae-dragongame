using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses
{
    public interface IAnimatable
    {
        bool Animating { get; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 basePosition);
    }
}
