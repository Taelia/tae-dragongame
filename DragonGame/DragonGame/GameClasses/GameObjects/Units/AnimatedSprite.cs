using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses
{
    public class AnimatedSprite
    {
        private Texture2D _spriteSheet;
        private int _imageCount;

        private Rectangle _spriteRect;

        private int _spriteWidth;
        private int _spriteHeight;

        private double _timer = 0;
        private double _interval = 100;
        private int _curFrame = 0;

        public AnimatedSprite(Texture2D spriteSheet, int imageCount)
        {
            _spriteSheet = spriteSheet;
            _imageCount = imageCount;

            _spriteWidth = _spriteSheet.Width / _imageCount;
            _spriteHeight = _spriteSheet.Height;

            _spriteRect = new Rectangle(0, 0, _spriteWidth, _spriteHeight);
        }

        public void Update(GameTime gameTime)
        {
            _timer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_timer >= _interval)
            {
                _timer = 0;
                _curFrame = (_curFrame+1) % _imageCount;
            }
            _spriteRect.X = _curFrame * _spriteWidth;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(_spriteSheet, new Rectangle((int)position.X, (int)position.Y, _spriteWidth, _spriteHeight), _spriteRect, color);
        }
    }
}
