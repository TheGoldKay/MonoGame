using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//using SharpDX.Direct2D1;

namespace ShootingGallery
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D targetSprite;
        Texture2D crosshairsSprite;
        Texture2D backgroundSprite;
        SpriteFont galleryFont;
        int winWidth;
        int winHeight;
        Vector2 targetPos;
        int targetRadius;
        MouseState mState;
        bool mRelease = true;
        int score = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            winWidth = GraphicsDevice.Viewport.Width;
            winHeight = GraphicsDevice.Viewport.Height;
            targetPos = Vector2.Zero;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            targetSprite = Content.Load<Texture2D>("target");
            targetRadius = targetSprite.Width / 2;
            crosshairsSprite = Content.Load<Texture2D>("crosshairs");
            backgroundSprite = Content.Load<Texture2D>("sky");
            galleryFont = Content.Load<SpriteFont>("galleryFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            targetPos = getPos();
            mState = Mouse.GetState();
            if (mState.LeftButton == ButtonState.Pressed && mRelease)
            {
                Console.WriteLine("Pressed");
                mRelease = false;
                score++;
            }
            if (mState.LeftButton == ButtonState.Released)
            {
                mRelease = true;
            }
            base.Update(gameTime);
        }

        private Vector2 getPos() 
        {
            MouseState mouseState = Mouse.GetState();
            Vector2 pos = new Vector2(mouseState.X - targetSprite.Width / 2, mouseState.Y - targetSprite.Height / 2);
            if (pos.X < 0)
            {
                pos.X = 0;
            } 
            else if (pos.X + targetSprite.Width > winWidth)
            {
                pos.X = winWidth - targetSprite.Width;
            }
            if (pos.Y < 0)
            {
                pos.Y = 0;
            }
            else if (pos.Y + targetSprite.Height > winHeight)
            {
                pos.Y = winHeight - targetSprite.Height;
            }
            return pos;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
            //_spriteBatch.Draw(targetSprite, targetPos, Color.White);
            _spriteBatch.DrawString(galleryFont, "Score: ", new Vector2(0, 0), Color.Black);
            _spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}
