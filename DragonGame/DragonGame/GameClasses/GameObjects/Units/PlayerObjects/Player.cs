using DragonGame.GameClasses;
using DragonGame.GameClasses.AttackClasses;
using DragonGame.GameClasses.Jobs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TomeLib.Db;

namespace DragonGame.GameClasses
{
    public class Player
    {
        public string Name;
        public bool Dead;

        public Stat Level = new Stat("Level", 1, 99);

        public Stat Karma = new Stat("Karma", 0, 1000);
        public Stat Exp = new Stat("Exp", 0, 1000);
        public Stat Coins = new Stat("Coins", 0, 9999999);

        public Stat HP = new Stat("HP", 0, 1000);
        public Stat MP = new Stat("MP", 0, 100);

        public DateTime LastSeen;

        public BaseJob Job;

        private IAnimatable _currentAnimation;
        private IAnimatable _idleAnimation;

        public Player(string name)
        {
            this.Name = name;

            HP.Value = HP.Max;
            MP.Value = MP.Max;
        }

        public void Initialize(int level, int exp, string job, DateTime lastSeen)
        {
            Level.Value = level;
            Exp.Value = exp;


            LastSeen = lastSeen;
            ChangeJob(job);
        }

        public void Update(GameTime gameTime)
        {
            HP.Update(gameTime);
            MP.Update(gameTime);

            if (_currentAnimation != null)
                _currentAnimation.Update(gameTime);
            if (_idleAnimation != null)
            _idleAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 basePosition)
        {
            if (_currentAnimation != null && _currentAnimation.Animating)
                _currentAnimation.Draw(spriteBatch, basePosition);
            else if (_idleAnimation != null)
                _idleAnimation.Draw(spriteBatch, basePosition);
        }

        public BaseAttack Ability()
        {
            var attack = Job.Attack();
            _currentAnimation = attack;
            return attack;
        }

        public BaseAttack Attack()
        {
            var attack = Job.Attack();
            _currentAnimation = attack;
            return attack;
        }

        public void Defend(BaseAttack attack)
        {
            if (HP.Value == 0) HP.Value = HP.Max;

            HP.ChangeValue(-1 * attack.Damage);
        }

        public void ChangeJob(string job)
        {
            job = job.ToUpper();

            switch (job)
            {
                case "BLB": Job = new BlackBelt(this); break;
                case "BLM": Job = new BlackMage(this); break;
                case "BRD": Job = new Bard(this); break;
                case "DEV": Job = new Devout(this); break;
                case "DRG": Job = new Dragoon(this); break;
                case "DRK": Job = new DarkKnight(this); break;
                case "EVO": Job = new Evoker(this); break;
                case "GEO": Job = new Geomancer(this); break;
                case "KNI": Job = new Knight(this); break;
                case "MAG": Job = new Magus(this); break;
                case "MNK": Job = new Monk(this); break;
                case "NIN": Job = new Ninja(this); break;
                case "ONK": Job = new OnionKnight(this); break;
                case "RDM": Job = new RedMage(this); break;
                case "RNG": Job = new Ranger(this); break;
                case "SAG": Job = new Sage(this); break;
                case "SCH": Job = new Scholar(this); break;
                case "SMN": Job = new Summoner(this); break;
                case "THF": Job = new Thief(this); break;
                case "VIK": Job = new Viking(this); break;
                case "WAR": Job = new Warrior(this); break;
                case "WHM": Job = new WhiteMage(this); break;
            }

            _idleAnimation = new IdleAnimation(Job);
        }
    }
}
