using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Snake
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        string fontName1 = "Arial";
        string fontName2 = "gamefont";
        SpriteFont font;
        Vector2 titlePos;
        int window_width = 800;
        int window_height = 600;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.IsBorderless = true;
            _graphics.PreferredBackBufferWidth = window_width;
            _graphics.PreferredBackBufferHeight = window_height;
            titlePos = new Vector2(window_width / 2 - 100, 10);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>(fontName2);
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
            GraphicsDevice.Clear(Color.Crimson);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, "Snake Game", titlePos, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
