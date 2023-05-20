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
        public float Rot;
        public Vector2 Pos, Dims;
        public Texture2D Model;

        public Element2d(string path, Vector2 position, Vector2 dimensions)
        {
            Pos = position;
            Dims = dimensions;
            Model = Globals.content.Load<Texture2D>(path);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(Vector2 offset)
        {
            if (Model != null)
            {
                Globals.spriteBatch.Draw(
                    Model,
                    new Rectangle((int)(Pos.X + offset.X), (int)(Pos.Y + offset.Y), (int)Dims.X, (int)Dims.Y),
                    null,
                    Color.White,
                    Rot,
                    new Vector2(Model.Bounds.Width / 2, Model.Bounds.Height / 2),
                    new SpriteEffects(),
                    0);
            }
        }

        public virtual void Draw(Vector2 offset, Vector2 origin)
        {
            if (Model != null)
            {
                Globals.spriteBatch.Draw(
                    Model,
                    new Rectangle((int)(Pos.X + offset.X), (int)(Pos.Y + offset.Y), (int)Dims.X, (int)Dims.Y),
                    null,
                    Color.White,
                    Rot,
                    new Vector2(origin.X, origin.Y),
                    new SpriteEffects(),
                    0);
            }
        }
    }
}
