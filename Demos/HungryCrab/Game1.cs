using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HungryCrab
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Rectangle crabRect;
        private Texture2D crabAsset;
        private Vector2 crabDir = Vector2.Zero;
        private float crabSpeed = 100; // pixels per second

        private KeyboardState prevKBState;

        private SpriteFont defaultFont;
        private SpriteFont titleFont;

        private Vector2 titleLoc = Vector2.Zero;
        private Vector2 posUILoc;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            crabAsset = Content.Load<Texture2D>("Crab");
            crabRect = new Rectangle(0, 0, crabAsset.Width/6, crabAsset.Height/6);

            defaultFont = Content.Load<SpriteFont>("defaultFont");
            titleFont = Content.Load<SpriteFont>("titleFont");

            float titleHeight = titleFont.MeasureString("TMP").Y;
            posUILoc = new Vector2(0,titleHeight+5);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState currentKBState = Keyboard.GetState();

            crabDir = Vector2.Zero;

            // if down last frame and up now
            if(prevKBState.IsKeyDown(Keys.Space) && currentKBState.IsKeyUp(Keys.Space))
            {
                crabSpeed += 25;
            }

            if (currentKBState.IsKeyDown(Keys.W))
            {
                crabDir.Y = -1;
            }

            if (currentKBState.IsKeyDown(Keys.S))
            {
                crabDir.Y = 1;
            }

            if (currentKBState.IsKeyDown(Keys.A))
            {
                crabDir.X = -1;
            }

            if (currentKBState.IsKeyDown(Keys.D))
            {
                crabDir.X = 1;
            }

            //crabDir.Normalize();

            // Use direction & speed to calc velocity
            Vector2 velocity = 
                crabDir * 
                (crabSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);

            crabRect.X += (int)velocity.X;
            crabRect.Y += (int)velocity.Y;

            prevKBState = currentKBState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(crabAsset, crabRect, Color.White);

            _spriteBatch.DrawString(
                titleFont,
                "Hungry Crab!",
                titleLoc,
                Color.Black);

            _spriteBatch.DrawString(
                defaultFont,
                crabDir.X + ", " + crabDir.Y+" - "+crabSpeed,
                posUILoc,
                Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
