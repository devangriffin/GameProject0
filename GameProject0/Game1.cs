using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace GameProject0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D surface;
        private Texture2D sunAtlas;
        private Rectangle[] currentSun;
        private double animationTimer;
        private int animationFrame = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferHeight = 648;
            graphics.PreferredBackBufferWidth = 1152;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            currentSun = new Rectangle[4];
            currentSun[0] = new Rectangle(0, 0, 128, 128);
            currentSun[1] = new Rectangle(128, 0, 128, 128);
            currentSun[2] = new Rectangle(256, 0, 128, 128);
            currentSun[3] = new Rectangle(384, 0, 128, 128);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            surface = Content.Load<Texture2D>("MoonSurface");
            sunAtlas = Content.Load<Texture2D>("FunSun");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here

            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer > 0.15)
            {
                animationFrame++;
                if (animationFrame == 4) animationFrame = 0;
                animationTimer -= 0.15;
            }

            spriteBatch.Begin();
            spriteBatch.Draw(sunAtlas, new Vector2(576, 324), currentSun[animationFrame], Color.White);
            spriteBatch.Draw(surface, new Rectangle(0, 0, 1152, 648), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}