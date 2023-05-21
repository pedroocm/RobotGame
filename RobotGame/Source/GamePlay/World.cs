#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace RobotGame
{
    public class World
    {
        public Vector2 offset;

        public RobotBoy RobotBoy;

        public List<Projectile> Projectiles = new List<Projectile>();

        public World()
        {
            RobotBoy = new RobotBoy("player\\robotboyR", new Vector2(300, 300), new Vector2(90, 90));

            GameGlobals.PassProjectile = AddProjectile;

            offset = Vector2.Zero;
        }

        public virtual void Update()
        {
            RobotBoy.Update();

            for (int i = 0; i < Projectiles.Count; ++i)
            {
                Projectiles[i].Update(offset, null);

                if (Projectiles[i].Done) Projectiles.RemoveAt(i--);
            }
        }

        public virtual void AddProjectile(object info)
        {
            Projectiles.Add((Projectile)info);
        }

        public virtual void Draw(Vector2 offset)
        {
            RobotBoy.Draw(offset);

            foreach (var projectile in Projectiles)
                projectile.Draw(offset);
        }
    }
}
