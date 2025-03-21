using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace PE_MarioWalking
{
    // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
    // PRACTICE EXERCISE:  Enums are typically declared here!

    // Mario State enum
    enum MarioState
    {
        FaceLeft,
        WalkLeft,
        FaceRight,
        WalkRight // TODO: Add state(s) to support crouching
    }

    // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

    class Mario
    {
        Vector2 marioLoc;       // Mario's location on the screen
        MarioState state;

        // Texture and drawing
        Texture2D spriteSheet;  // The single image with all of the animation frames

        // Animation
        int frame;              // The current animation frame
        double timeCounter;     // The amount of time that has passed
        double fps;             // The speed of the animation
        double timePerFrame;    // The amount of time (in fractional seconds) per frame

        // Constants for "source" rectangle (inside the image)
        const int WalkFrameCount = 3;       // The number of frames in the animation
        const int MarioRectOffsetY = 116;   // How far down in the image are the frames?
        const int MarioRectHeight = 72;     // The height of a single frame
        const int MarioRectWidth = 44;      // The width of a single frame

        // Properties to get & set Mario's current location and animation state
        public float X
        {
            get
            {
                return this.marioLoc.X;
            }
            set
            {
                this.marioLoc.X = value;
            }
        }

        public MarioState State {
            get { return state; }
            set { state = value; }
        }

        // The constructor takes the sprite sheet to use and the initial location
        public Mario(Texture2D spriteSheet, Vector2 marioLoc, MarioState startingState)
        {
            this.spriteSheet = spriteSheet;
            this.marioLoc = marioLoc;
            this.state = startingState;

            // Initialize
            fps = 10.0;                     // Will cycle through 10 walk frames per second
            timePerFrame = 1.0 / fps;       // Time per frame = amount of time in a single walk image
        }

        /// <summary>
        /// Updates mario's animation as necessary
        /// </summary>
        /// <param name="gameTime">Time information</param>
        public void UpdateAnimation(GameTime gameTime)
        {
            // Handle animation timing
            // - Add to the time counter
            // - Check if we have enough "time" to advance the frame

            // How much time has passed?  
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;

            // If enough time has passed:
            if (timeCounter >= timePerFrame)
            {
                frame += 1;                     // Adjust the frame to the next image

                if (frame > WalkFrameCount)     // Check the bounds - have we reached the end of walk cycle?
                    frame = 1;                  // Back to 1 (since 0 is the "standing" frame)

                timeCounter -= timePerFrame;    // Remove the time we "used" - don't reset to 0
                                                // This keeps the time passed 
            }
        }

        /// <summary>
        /// Draws Mario onto the given sprite batch based on his current state (and
        /// the current frame in the animation)
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            // TODO: Check the finite state machine state here to
            // determine how exactly to draw Mario
            DrawWalking(SpriteEffects.None, spriteBatch); // You may alter/remove this line

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        }

        /// <summary>
        /// Draws only the left-most frame of mario, which is him standing
        /// </summary>
        /// <param name="flipSprite">
        /// Enum values for flipping the sprite horizontally
        /// and or vertically
        /// </param>
        private void DrawStanding(SpriteEffects flipSprite, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                spriteSheet,                    // - The texture to draw
                marioLoc,                       // - The location to draw on the screen
                new Rectangle(                  // - The "source" rectangle
                    0,                          //   - This rectangle specifies
                    MarioRectOffsetY,           //	   where "inside" the texture
                    MarioRectWidth,             //     to get pixels (We don't want to
                    MarioRectHeight),           //     draw the whole thing)
                Color.White,                    // - The color
                0,                              // - Rotation (none currently)
                Vector2.Zero,                   // - Origin inside the image (top left)
                1.0f,                           // - Scale (100% - no change)
                flipSprite,                     // - Can be used to flip the image
                0);                             // - Layer depth (unused)
        }

        /// <summary>
        /// Draws mario running, based on the current FRAME field
        /// which is changed by the code in Update
        /// </summary>
        /// <param name="flipSprite">
        /// Enum values for flipping the sprite horizontally
        /// and or vertically
        /// </param>
        private void DrawWalking(SpriteEffects flipSprite, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                spriteSheet,                    // - The texture to draw
                marioLoc,                       // - The location to draw on the screen
                new Rectangle(                  // - The "source" rectangle
                    frame * MarioRectWidth,     //   - This rectangle specifies
                    MarioRectOffsetY,           //	   where "inside" the texture
                    MarioRectWidth,             //     to get pixels (We don't want to
                    MarioRectHeight),           //     draw the whole thing)
                Color.White,                    // - The color
                0,                              // - Rotation (none currently)
                Vector2.Zero,                   // - Origin inside the image (top left)
                1.0f,                           // - Scale (100% - no change)
                flipSprite,                     // - Can be used to flip the image
                0);                             // - Layer depth (unused)
        }

        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // PRACTICE EXERCISE: 
        // Like the standing & walking methods above, you should only need ONE method
        // to handle drawing Mario crouching both left and right
        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        // TODO: Add a method to support drawing Mario crouching
    }
}
