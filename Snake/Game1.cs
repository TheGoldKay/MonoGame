using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Snake
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        string fontName = "gamefont";
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
            this.Window.IsBorderless = true;
            _graphics.PreferredBackBufferWidth = window_width;
            _graphics.PreferredBackBufferHeight = window_height;
            titlePos = new Vector2(window_width / 2 - 100, 10);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>(fontName);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, "Snake Game", titlePos, Color.Pink);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
