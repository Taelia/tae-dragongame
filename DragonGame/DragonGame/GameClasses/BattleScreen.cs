using DragonGame.GameClasses.AttackClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame.GameClasses
{
    public class BattleScreen
    {
        private Dragon _dragon;

        private Player _currentPlayer;
        private Queue<Player> _previousPlayers = new Queue<Player>();

        private enum MessageTarget { PLAYERATTACK, PLAYERABILITY, DRAGONATTACK, DRAGONABILITY, NONE };

        public BattleScreen()
        {
            _dragon = new Dragon();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            //Background black square
            spriteBatch.Draw(GameLoop.WhitePixel, new Rectangle(10, 200, 256, 256), Color.Black);

            _dragon.HP.Draw(spriteBatch, new Rectangle(10, 180, 256, 16), Color.Green, Color.LightGreen);

            if (_currentPlayer != null) DrawCurrentPlayer(spriteBatch);
            DrawPreviousPlayers(spriteBatch);
        }

        private void DrawCurrentPlayer(SpriteBatch spriteBatch)
        {
            var nameWidth = GameLoop.JupiterFont.MeasureString(_currentPlayer.Name).X;
            var jobWidth = GameLoop.JupiterFont.MeasureString(_currentPlayer.Job.Name + _currentPlayer.Level.Value.ToString()).X;

            spriteBatch.DrawString(GameLoop.JupiterFont, _currentPlayer.Job.Name + _currentPlayer.Level.Value.ToString(), new Vector2((int)(105 - jobWidth / 2f), 230), Color.White);
            spriteBatch.DrawString(GameLoop.JupiterFont, _currentPlayer.Name, new Vector2((int)(105 - nameWidth / 2f), 200), Color.White);

            spriteBatch.DrawString(GameLoop.JupiterFont, "exp", new Vector2(40, 245), Color.White);
            _currentPlayer.Exp.Draw(spriteBatch, new Rectangle(70, 260, 70, 8), Color.Goldenrod, Color.Yellow);

            _currentPlayer.Draw(spriteBatch, new Vector2(90, 300));

            spriteBatch.DrawString(GameLoop.JupiterFont, "HP", new Vector2(20, 390), Color.White);
            _currentPlayer.HP.Draw(spriteBatch, new Rectangle(50, 400, 120, 16), Color.Green, Color.LightGreen);
            spriteBatch.DrawString(GameLoop.JupiterFont, "MP", new Vector2(20, 412), Color.White);
            _currentPlayer.MP.Draw(spriteBatch, new Rectangle(50, 416, 120, 16), Color.DarkBlue, Color.DodgerBlue);
        }

        private void DrawPreviousPlayers(SpriteBatch spriteBatch)
        {
            var posX = 216;
            var posY = 224;
            foreach (Player p in _previousPlayers.Reverse())
            {
                p.Draw(spriteBatch, new Vector2(posX, posY));
                p.HP.Draw(spriteBatch, new Rectangle(posX, posY + 54, 34, 6), Color.Green, Color.Lime);
                p.MP.Draw(spriteBatch, new Rectangle(posX, posY + 60, 34, 6), Color.DarkBlue, Color.DodgerBlue);
                posY += 72;
            }
        }

        public void Update(GameTime gameTime)
        {
            _dragon.Update(gameTime);

            if (_currentPlayer != null)
                _currentPlayer.Update(gameTime);
            foreach (Player p in _previousPlayers)
                p.Update(gameTime);
        }


        public void InitiateFight(Player attacker, string message)
        {
            var target = ParseMessage(message);
            if (target == MessageTarget.NONE) return;

            SetPlayers(attacker);

            Fight(target);
        }

        private MessageTarget ParseMessage(string message)
        {
            if (message.Contains("Kappa") || message.Contains("Keepo") || message.Contains("Kippa"))
                return MessageTarget.DRAGONABILITY;
            else if (message.Contains("<3"))
                return MessageTarget.PLAYERABILITY;
            else if (message.Length > 40)
                return MessageTarget.PLAYERATTACK;
            else if (message.Length < 10)
                return MessageTarget.DRAGONATTACK;
            else return MessageTarget.NONE;
        }

        private void SetPlayers(Player attacker)
        {
            //Just skip a turn if player talks too fast.
            if (_previousPlayers.Contains(attacker) || attacker == _currentPlayer) return;

            //If a new person enters the battle, switch positions
            //TODO: Animate the switching of positions
            if (_previousPlayers.Count >= 3)
                _previousPlayers.Dequeue();
            if (_currentPlayer != null)
                _previousPlayers.Enqueue(_currentPlayer);
            _currentPlayer = attacker;
        }

        private void Fight(MessageTarget target)
        {
            BaseAttack attack = null;

            //Receive an attack object depending on the contents of the message received.
            switch (target)
            {
                case MessageTarget.PLAYERATTACK:
                    attack = _currentPlayer.Attack();
                    break;
                case MessageTarget.PLAYERABILITY:
                    attack = _currentPlayer.Ability();
                    break;
                case MessageTarget.DRAGONATTACK:
                    attack = _dragon.Attack();
                    break;
                case MessageTarget.DRAGONABILITY:
                    attack = _dragon.Ability();
                    break;
            }

            //Pass the attack along to the targets and let them deal with it.
            switch (attack.Target)
            {
                case AttackTarget.DRAGON:
                    _dragon.Defend(attack);
                    break;
                case AttackTarget.FRONTROW:
                    _currentPlayer.Defend(attack);
                    break;
                case AttackTarget.BACKROW:
                    foreach (Player p in _previousPlayers)
                        p.Defend(attack);
                    break;
                case AttackTarget.ALL:
                    _currentPlayer.Defend(attack);
                    foreach (Player p in _previousPlayers)
                        p.Defend(attack);
                    break;
            }
        }
    }
}
