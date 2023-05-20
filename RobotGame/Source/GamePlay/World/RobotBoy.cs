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
    public class RobotBoy : Element2d
    {
        public float Speed;
        public Texture2D Left, Right, Up, Down;
        public int BodyDir, WheelsDir;

        Element2d Body, Wheel;

        public RobotBoy(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            Speed = 2.0f;

            Body = new Element2d(path, position, dimensions);

            Left  = Globals.content.Load<Texture2D>("sprites\\robotboyL");
            Right = Globals.content.Load<Texture2D>("sprites\\robotboyR");
            Up    = Globals.content.Load<Texture2D>("sprites\\robotboyU");
            Down  = Globals.content.Load<Texture2D>("sprites\\robotboyD");
        }

        public override void Update()
        {
            if(Globals.keyboard.Pressed("A"))
            {
                Pos = new Vector2(Pos.X - Speed, Pos.Y);
                WheelsDir = Constants.LEFT;
            }
            if (Globals.keyboard.Pressed("D"))
            {
                Pos = new Vector2(Pos.X + Speed, Pos.Y);
                WheelsDir = Constants.RIGHT;
            }
            if (Globals.keyboard.Pressed("W"))
            {
                Pos = new Vector2(Pos.X, Pos.Y - Speed);
                WheelsDir = Constants.UP;
            }
            if (Globals.keyboard.Pressed("S"))
            {
                Pos = new Vector2(Pos.X, Pos.Y + Speed);
                WheelsDir = Constants.DOWN;
            }

            BodyDir = Globals.GetDirection(Pos, Globals.mouse.GetScreenPos());
            
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

            base.Draw(offset);
        }
    }
}
