﻿#region Includes
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
    public class Globals
    {
        public static int screenWidth, screenHeight;
        public static ContentManager content;
        public static SpriteBatch spriteBatch;

        public static RgKeyboard keyboard;
        public static RgMouseControl mouse;


        public static float GetDistance(Vector2 pos, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
        }

        public static int GetDirection(Vector2 pos, Vector2 focus)
        {
            double dx = focus.X - pos.X, dy = focus.Y - pos.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (dx > 0) return Constants.RIGHT;
                return Constants.LEFT;
            }

            if (dy < 0) return Constants.UP;
            return Constants.DOWN;
        }

        public static float GetAngle(Vector2 pos, Vector2 focus)
        {

            float h, sineTheta, angle = 0f;
            if (pos.Y - focus.Y != 0)
            {
                h = GetDistance(pos, focus);
                sineTheta = (float)(Math.Abs(pos.Y - focus.Y) / h); //* ((item.pos.Y-focus.Y)/(Math.Abs(item.pos.Y-focus.Y))));
            }
            else
            {
                h = pos.X - focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            // Drawing diagonial lines here.
            //Quadrant 2
            if (pos.X - focus.X > 0 && pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }
            //Quadrant 3
            else if (pos.X - focus.X > 0 && pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }
            //Quadrant 1
            else if (pos.X - focus.X < 0 && pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (pos.X - focus.X < 0 && pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (pos.X - focus.X > 0 && pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI * 3 / 2;
            }
            else if (pos.X - focus.X < 0 && pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI / 2;
            }
            else if (pos.X - focus.X == 0 && pos.Y - focus.Y > 0)
            {
                angle = (float)0;
            }
            else if (pos.X - focus.X == 0 && pos.Y - focus.Y < 0)
            {
                angle = (float)Math.PI;
            }

            return angle;
        }
    }
}
