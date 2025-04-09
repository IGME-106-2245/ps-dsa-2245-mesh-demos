using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_DynamicTrees
{
    /// <summary>
    /// DO NOT MODIFY EXCEPT WHERE MARKED "TODO"!
    /// 
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		// The three trees
		Tree treeRed;
		Tree treeGreen;
		Tree treeBlue;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// Create the three trees
			treeRed = new Tree(Color.Red);
			treeGreen = new Tree(Color.Green);
			treeBlue = new Tree(Color.DodgerBlue);

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add logic to insert data into the red tree
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add logic to insert data into the green tree
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Add logic to insert data into the blue tree
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: If you want to play:
			//	AFTER you have the rest of the assignment working:
			//  What happens if you insert a new piece of 
			//  data into the trees each frame (or maybe every few frames)?

			base.Update(gameTime);
		}

		private void RecursiveDrawDemo(Vector2 startPos, float length)
		{
			// Base case -- small length
			if(length > 10)
			{
                Vector2 newPos = ShapeBatch.Line(startPos, length, 0.0f, Color.Red);
				newPos.X += 10;
				RecursiveDrawDemo(newPos, length * .8f);
			}

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

            // Shape Batch demo
            ShapeBatch.Begin(GraphicsDevice);
            RecursiveDrawDemo(new Vector2(20,20), 100);
            ShapeBatch.End();


            // Draw the trees
            treeRed.Draw(new Vector2(150, 400), GraphicsDevice);
			treeGreen.Draw(new Vector2(300, 300), GraphicsDevice);
			treeBlue.Draw(new Vector2(600, 400), GraphicsDevice);

			base.Draw(gameTime);
		}
	}
}
