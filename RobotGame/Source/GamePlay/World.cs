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
        RobotBoy robot_boy;
        public World()
        {
            robot_boy = new RobotBoy("sprites\\robotboyR", new Vector2(300, 300), new Vector2(90, 90));
        }

        public virtual void Update()
        {
            robot_boy.Update();
        }

        public virtual void Draw(Vector2 offset)
        {
            robot_boy.Draw(offset);
        }
    }
}
