using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace GameProject0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D surface;
        private Texture2D sunAtlas;
        private Texture2D car;
        private Texture2D man;
        private Texture2D star;
        private Texture2D earth;

        private Rectangle[] currentSun;
        private double animationTimer;
        private int animationFrame = 0;
        private SpriteFont bangers;
        private Color textColor;

        private Random random;
        private int[] newX;
        private int[] newY;
        private const int STARCOUNT = 30;

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

            random = new Random();

            newX = new int[STARCOUNT];
            newY = new int[STARCOUNT];

            for (int i = 0; i < STARCOUNT; i++)
            {
                newX[i] = random.Next(1152);
                newY[i] = random.Next(648);
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            surface = Content.Load<Texture2D>("MoonSurface");
            sunAtlas = Content.Load<Texture2D>("FunSun");
            bangers = Content.Load<SpriteFont>("bangers");
            car = Content.Load<Texture2D>("Car");
            man = Content.Load<Texture2D>("AstronautDude");
            star = Content.Load<Texture2D>("Star");
            earth = Content.Load<Texture2D>("Earth");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || 
                Keyboard.GetState().IsKeyDown(Keys.Space))
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

            textColor = Color.WhiteSmoke;
            if (animationFrame <= 1)
            {
                textColor = Color.Red;
            }

            spriteBatch.Begin();

            // Randomly puts stars on the screen
            for (int i = 0; i < STARCOUNT; i++)
            {
                spriteBatch.Draw(star, new Vector2(newX[i], newY[i]), null, Color.DarkKhaki,
                                 0f, new Vector2(0, 0), new Vector2(0.2f, 0.2f), SpriteEffects.None, 0);
            }

            // Draws images and strings
            spriteBatch.Draw(sunAtlas, new Vector2(384, 284), currentSun[animationFrame], Color.White, 
                             0f, new Vector2(0, 0), new Vector2(3, 3), SpriteEffects.None, 0);
            spriteBatch.Draw(surface, new Rectangle(0, 0, 1152, 648), Color.White);
            spriteBatch.DrawString(bangers, "THE BEGINNING", new Vector2(128, 0), Color.WhiteSmoke,
                                   0f, new Vector2(0, 0), new Vector2(1.5f, 1), SpriteEffects.None, 0);
            spriteBatch.DrawString(bangers, "Press Space to End", new Vector2(284, 164), textColor,
                                   0f, new Vector2(0, 0), new Vector2(0.75f, 0.5f), SpriteEffects.None, 0);
            spriteBatch.Draw(man, new Vector2(324, 444), Color.White);
            spriteBatch.Draw(car, new Vector2(700, 524), Color.White);
            spriteBatch.Draw(earth, new Vector2(164, 284), Color.White);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}