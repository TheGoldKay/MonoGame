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
        string partName = "snake_part";
        SpriteFont font;
        Vector2 titlePos;
        int window_width = 800;
        int window_height = 600;
        Texture2D snakePart;
        Vector2 headPos;

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
            headPos = new Vector2(100, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>(fontName);
            snakePart = Content.Load<Texture2D>(partName);
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
            _spriteBatch.Draw(snakePart, headPos, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
