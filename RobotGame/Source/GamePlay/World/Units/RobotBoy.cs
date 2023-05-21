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
    public class RobotBoy : Unit
    {
        public Texture2D Left, Right, Up, Down;
        public int BodyDir, WheelsDir;

        Element2d Body, Wheel;
        RobotGun gun;

        public RobotBoy(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            Speed = 2.0f;

            Body = new Element2d(path, position, dimensions);

            Left  = Globals.Content.Load<Texture2D>("player\\robotboyL");
            Right = Globals.Content.Load<Texture2D>("player\\robotboyR");
            Up    = Globals.Content.Load<Texture2D>("player\\robotboyU");
            Down  = Globals.Content.Load<Texture2D>("player\\robotboyD");

            gun = new RobotGun(Pos, new Vector2(40, 40), this);
        }

        public override void Update()
        {
            if(Globals.Keyboard.Pressed("A"))
            {
                Pos = new Vector2(Pos.X - Speed, Pos.Y);
                WheelsDir = Constants.LEFT;
            }
            if (Globals.Keyboard.Pressed("D"))
            {
                Pos = new Vector2(Pos.X + Speed, Pos.Y);
                WheelsDir = Constants.RIGHT;
            }
            if (Globals.Keyboard.Pressed("W"))
            {
                Pos = new Vector2(Pos.X, Pos.Y - Speed);
                WheelsDir = Constants.UP;
            }
            if (Globals.Keyboard.Pressed("S"))
            {
                Pos = new Vector2(Pos.X, Pos.Y + Speed);
                WheelsDir = Constants.DOWN;
            }

            BodyDir = Globals.GetDirection(Pos, Globals.Mouse.GetScreenPos());


            if (Globals.Mouse.LeftClick())
                gun.Shoot(this);

            gun.Update(new Vector2(Pos.X, Pos.Y));

            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            switch (BodyDir)
            {
                case Constants.LEFT:
                    Model = Left;
                    break;
                case Constants.RIGHT:
                    Model = Right;
                    break;
                case Constants.UP:
                    Model = Up;
                    break;
                case Constants.DOWN:
                    Model = Down;
                    break;
            }

            if (gun.isOnTop())
            {
                base.Draw(offset);
                gun.Draw(offset);
            }
            else
            {
                gun.Draw(offset);
                base.Draw(offset);
            }
        }
    }
}
