using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses
{
    public class Stat
    {
        public string Name;

        private int _value;

        public int Value { get { return _value; } set { _value = Clamp(value); _drawValue = _value; } }
        public int Min;
        public int Max;

        private int _drawValue;

        public Stat(string name, int min = 0, int max = 255)
        {
            Name = name;
            Min = min;
            Max = max;
        }

        public void ChangeValue(int relativeValue)
        {
            _value += relativeValue;
        }

        public void Update(GameTime gameTime)
        {
            if (_drawValue - Value > 1) _drawValue -= (_drawValue - Value) / 10;
            else if (_drawValue - Value < -1) _drawValue += (Value - _drawValue) / 10;
            else _drawValue = Value;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle position, Color emptyColor, Color fillColor)
        {
            spriteBatch.Draw(GameLoop.WhitePixel, position, emptyColor);
            var offset = position.Height / 5;
            double percentage = _drawValue / (double)Max;

            spriteBatch.Draw(GameLoop.WhitePixel, new Rectangle(position.X, position.Y + offset, (int)(position.Width * percentage), position.Height - (offset * 2)), fillColor);
        }

        private int Clamp(int value)
        {
            if (value < Min) return Min;
            if (value > Max) return Max;
            return value;
        }
    }
}
