using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InputTutorialExercise
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private Ball[] balls;
        private InputManager inputManager;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            balls = new Ball[] {
                new Ball(this, Color.Red) { Position = new Vector2(250, 200) },
                new Ball(this, Color.Green) { Position = new Vector2(350, 200) },
                new Ball(this, Color.Blue) { Position = new Vector2(450, 200) }
            };
            inputManager = new InputManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (Ball b in balls) b.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            inputManager.Update(gameTime);
            if (inputManager.Exit) Exit();

            balls[0].Position += inputManager.Position;

            if (inputManager.Warp) balls[0].Warp();
         
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (Ball b in balls) b.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
