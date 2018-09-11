using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CPI311.GameEngine;
namespace Lab02
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite sprite;
        SpriteAnimator spriteAnimator;

        private float _time = 1f;
        private float _radius = 100f;
        private float _speed = 1f;
        private float _wobbling = 10f;

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
            // TODO: Add your initialization logic here
            
            base.Initialize();
            TimeManager.Initialize();
            InputManager.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprite = new Sprite(Content.Load<Texture2D>("Square"));
            spriteAnimator = new SpriteAnimator(sprite, new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            // TODO: Add your update logic here
            base.Update(gameTime);
            TimeManager.Update(gameTime);
            InputManager.Update();
            base.Update(gameTime);

            TimeManager.Update(gameTime);
            InputManager.Update();

            _time += (float)TimeManager.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.Left))
                _radius += 5f;
            if (InputManager.IsKeyDown(Keys.Right))
                _radius -= 5f;
            if (InputManager.IsKeyDown(Keys.Down))
                _speed -= 0.1f;
            if (InputManager.IsKeyDown(Keys.Up))
                _speed += 0.1f;
            if (InputManager.IsKeyDown(Keys.LeftAlt))
                _wobbling -= 0.1f;
            if (InputManager.IsKeyDown(Keys.LeftControl))
                _wobbling += 0.1f;




            spriteAnimator.AnimateSpiralSinusoidal(_radius, _time, _speed, _wobbling);


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            sprite.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
