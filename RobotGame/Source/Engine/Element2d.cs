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
    public class Element2d
    {
        public Vector2 pos, dims;
        public Texture2D model;

        public Element2d(string path, Vector2 position, Vector2 dimensions)
        {
            pos = position;
            dims = dimensions;

            model = Globals.content.Load<Texture2D>(path);
        }

        public void Update()
        {

        }

        public void Draw()
        {
            if (model != null)
            {
                Globals.spriteBatch.Draw(
                    model,
                    new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y),
                    null,
                    Color.White,
                    0.0f,
                    new Vector2(model.Bounds.Width / 2, model.Bounds.Height / 2),
                    new SpriteEffects(),
                    0);
            }
        }
    }
}
