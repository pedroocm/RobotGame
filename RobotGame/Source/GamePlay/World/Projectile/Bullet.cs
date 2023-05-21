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
    internal class Bullet : Projectile
    {
        public Bullet(Vector2 position, Unit owner, Vector2 direction) :
            base("projectiles\\bullet", position, new Vector2(10, 10), owner, direction)
        {
        }
    }
}
