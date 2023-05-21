#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace RobotGame
{
    public class Projectile : Element2d
    {
        public bool Done;
        public float Speed;
        public Vector2 Direction;
        public Unit Owner;
        public RgTimer Timer;
        
        public Projectile(string path, Vector2 position, Vector2 dimensions, Unit owner, Vector2 direction) : base(path, position, dimensions)
        {
            Done = false;
            Speed = 10.0f;
            Direction = direction;
            Direction.Normalize();
            Owner = owner;
            Timer = new RgTimer(1200);
            Rot = Globals.GetAngle(Vector2.Zero, direction);
        }

        public virtual void Update(Vector2 offset, List<Unit> units)
        {
            Pos += Direction * Speed;

            Timer.UpdateTimer();

            if (Timer.Test()) Done = true;

            if (Hitted(units)) Done = true;
        }

        public virtual bool Hitted(List<Unit> units)
        {
            return false;
        }
    }
}
