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
    public class Unit : Element2d
    {
        public float Speed;

        public Unit(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            Speed = 2.0f;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
