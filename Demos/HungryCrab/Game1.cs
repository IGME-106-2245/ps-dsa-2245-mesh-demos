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

        private Rectangle window;

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
            window = new Rectangle(0, 0, 800, 600);
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

            #region direction updates
            if (currentKBState.IsKeyDown(Keys.W))
            {
                crabDir.Y--;
            }

            if (currentKBState.IsKeyDown(Keys.S))
            {
                crabDir.Y++;
            }

            if (currentKBState.IsKeyDown(Keys.A))
            {
                crabDir.X--;
            }

            if (currentKBState.IsKeyDown(Keys.D))
            {
                crabDir.X++;
            }
            #endregion

            if (crabDir != Vector2.Zero)
            {
                crabDir.Normalize();
            }

            // Use direction & speed to calc velocity (pixels/sec)
            Vector2 velocity = crabDir * crabSpeed;

            Vector2 travelDist = velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            crabRect.X += (int)travelDist.X;
            crabRect.Y += (int)travelDist.Y;


            // screen wrap if we're outside the window

            if(!crabRect.Intersects(window))
            {
                // if outside the left side, teleport to the right
                if(crabRect.Right < window.Left)
                {
                    crabRect.X = window.Right - crabRect.Width;
                }
            }



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

            //Singleton tmp = new Singleton();
            _spriteBatch.DrawString(defaultFont, Singleton.Instance.ToString(), new Vector2(200, 200), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
