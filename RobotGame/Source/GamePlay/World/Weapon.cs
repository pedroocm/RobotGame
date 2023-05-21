using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace RobotGame
{
    public class Weapon : Element2d
    {
        public Unit Owner;
        public Weapon(string path, Vector2 position, Vector2 dimensions, Unit owner) : base(path, position, dimensions)
        {
            Owner = owner;
        }

        public virtual bool isOnTop()
        {
            return Rot < MathHelper.Pi;
        }

        public virtual void Shoot(Unit unit)
        {
            Vector2 direction = Globals.Mouse.GetScreenPos() - Pos;
            direction.Normalize();
            GameGlobals.PassProjectile(
                new Bullet(Globals.GetVector(Pos + (direction * Dims.X)), unit, direction)
            );
        }

        public virtual void Update(Vector2 pos)
        {
            Rot = Globals.GetAngle(Pos, Globals.Mouse.GetScreenPos());
            Pos = new Vector2(pos.X, pos.Y);
            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset, new Vector2(-Model.Bounds.Width / 3, Model.Bounds.Height / 2));
        }
    }
}
