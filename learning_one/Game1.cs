using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.Cryptography.X509Certificates;
namespace learning_one;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    int win_width = 1200;
    int win_height = 800;
    Texture2D targetSprite;
    Texture2D crosshairsSprite;
    double crosshairsTimer = 1.0;
    double crosshairsClock = 0.0;
    bool drawCrosshairs = false;
    float[] crosshairsPos = new float[2];
    Texture2D backgroundSprite;
    SpriteFont gameFont;
    Vector2 targetPosition = new Vector2(600, 400);
    MouseState mouseState;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        // change window's dimensions
        _graphics.PreferredBackBufferWidth = win_width;
        _graphics.PreferredBackBufferHeight = win_height;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Window.Title = "Target Game"; // Set the title of the window
        base.Initialize();
        
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        targetSprite = Content.Load<Texture2D>("target");
        crosshairsSprite = Content.Load<Texture2D>("crosshairs");
        backgroundSprite = Content.Load<Texture2D>("sky");
        gameFont = Content.Load<SpriteFont>("galleryFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        mouseState = Mouse.GetState();
        float mx = mouseState.X;
        float my = mouseState.Y;
        float tr = targetSprite.Width / 2;
        float tx = targetPosition.X + tr / 2;
        float ty = targetPosition.Y + tr / 2;
        if(_hovering_target(mx, my, tx, ty, tr) && mouseState.LeftButton == ButtonState.Pressed)
        {
            drawCrosshairs = true;
            crosshairsPos[0] = mx;
            crosshairsPos[1] = my;
        }
        base.Update(gameTime);
    }

    public void _change_target(float tr)
    {
            var random = new Random();
            float x = random.Next(0, win_width - (int)tr);
            float y = random.Next(0, win_height - (int)tr);
            targetPosition.X = x;
            targetPosition.Y = y;
    }
    public bool _hovering_target(float mx, float my, float tx, float ty, float tr)
    {
        float distanceSquared = (mx - tx) * (mx - tx) + (my - ty) * (my - ty);
        float radiusSquared = tr * tr;

        return distanceSquared <= radiusSquared;
    }

    protected override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
        _spriteBatch.DrawString(gameFont, "Hover over the target", new Vector2(win_width / 2 - gameFont.MeasureString("Click The Target").X / 2, 20), Color.Black);
        _spriteBatch.Draw(targetSprite, new Vector2(targetPosition.X, targetPosition.Y), Color.White);
        if(drawCrosshairs)
        {
            _spriteBatch.Draw(crosshairsSprite, new Vector2(crosshairsPos[0] - 20, crosshairsPos[1] - 20), Color.White);
            crosshairsClock += gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;

        }
        if(crosshairsClock >= crosshairsTimer)
        {
            crosshairsClock = 0.0;
            drawCrosshairs = false;
            _change_target(targetSprite.Width / 2);
        }
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
