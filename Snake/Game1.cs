using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SnakeBody;
using Food;

namespace Snake
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        string fontName = "gamefont";
        string partName = "snake_part";
        string headName = "shead";
        SpriteFont font;
        Vector2 titlePos;
        int window_width = 800;
        int window_height = 500;
        Texture2D snakePart;
        Texture2D headPart;
        Vector2 headPos;
        MakeSnake snake;
        MakeFood food;


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
            _graphics.ApplyChanges();
            titlePos = new Vector2(window_width / 2 - 100, 10);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>(fontName);
            snakePart = Content.Load<Texture2D>(partName);
            headPart = Content.Load<Texture2D>(headName);
            headPos = new Vector2(window_width / 2, window_height / 2);
            snake = new MakeSnake(snakePart, headPart, headPos, window_width, window_height);
            food = new MakeFood(Content, window_width, window_height);
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            snake.update(dt);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, "Snake Game", titlePos, Color.Pink);
            snake.draw(_spriteBatch);
            food.draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
