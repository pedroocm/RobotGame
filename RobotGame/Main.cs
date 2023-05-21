using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RobotGame
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;

        World World;

        Element2d Cursor;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.ScreenWidth = 800;
            Globals.ScreenHeight = 500;

            graphics.PreferredBackBufferWidth = Globals.ScreenWidth;
            graphics.PreferredBackBufferHeight = Globals.ScreenHeight;

            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.Content = this.Content;
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            Cursor = new Element2d("2d\\ui_basics\\cursor", new Vector2(0, 0), new Vector2(32, 32));

            Globals.Keyboard = new RgKeyboard();
            Globals.Mouse = new RgMouseControl();

            World = new World();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Globals.GameTime = gameTime;

            Globals.Keyboard.Update();
            Globals.Mouse.Update();

            World.Update();

            Globals.Keyboard.UpdateOld();
            Globals.Mouse.UpdateOld();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Globals.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);


            World.Draw(Vector2.Zero);

            Cursor.Draw(new Vector2(Globals.Mouse.newMousePos.X, Globals.Mouse.newMousePos.Y), new Vector2(0, 0));

            Globals.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}