using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_MGBasics
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int frameCount = 0;
        private Texture2D crabTexture;
        private Rectangle crabPosition;

        private int DesiredWidth = 700;
        private int DesiredHeight = 700;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = DesiredWidth;
            _graphics.PreferredBackBufferHeight = DesiredHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            System.Diagnostics.Debug.WriteLine("LoadContent! - "+frameCount);
            crabTexture = Content.Load<Texture2D>("Crab");
            crabPosition = new Rectangle(
                DesiredWidth/2 - crabTexture.Width/4/2, 
                DesiredHeight/2 - crabTexture.Height/4/2, 
                crabTexture.Width / 4, 
                crabTexture.Height / 4);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //System.Diagnostics.Debug.WriteLine("HELLO! - "+frameCount);
            frameCount++;

            crabPosition.X++;
            crabPosition.Y++;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SeaGreen);

            // TODO: Add your drawing code here

            // Begin the Sprite Batch
            _spriteBatch.Begin();

            _spriteBatch.Draw(crabTexture, new Vector2(10, 10), Color.White);
            _spriteBatch.Draw(crabTexture,
                crabPosition, 
                Color.Blue);


            // End the Sprite Batch
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
