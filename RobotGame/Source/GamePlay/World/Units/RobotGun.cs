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
    public class RobotGun : Weapon
    {
        public RobotGun(Vector2 position, Vector2 dimensions, Unit owner) : base("weapons\\robot_gun", position, dimensions, owner)
        {

        }
    }
}
