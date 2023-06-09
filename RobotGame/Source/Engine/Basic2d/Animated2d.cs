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
    internal class Animated2d : Element2d
    {
        public List<FrameAnimation> Animations;
        Vector2 FrameSize;

        public Animated2d(string path, Vector2 position, Vector2 dimensions, Vector2 NumberOfFrames) : base(path, position, dimensions)
        {
            FrameSize = new Vector2(Model.Bounds.Width / NumberOfFrames.X, Model.Bounds.Height / NumberOfFrames.Y);
        }

        public override void Update()
        {

            base.Update();
        }
    }
}
