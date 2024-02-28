using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Security.Cryptography.X509Certificates;
namespace learning_one;


class Circle
{
    public Vector2 Center { get; set; }
    public float Radius { get; set; }

    public bool Intersects(Circle otherCircle)
    {
        // Calculate the distance between the centers of the circles
        float distance = Vector2.Distance(Center, otherCircle.Center);

        // If the distance is less than or equal to the sum of the radii, there is a collision
        return distance <= (Radius + otherCircle.Radius);
    }
}

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    int win_width = 1200;
    int win_height = 800;
    Texture2D targetSprite;
    Texture2D crosshairsSprite;
    double crosshairsTimer = 0.5;
    double crosshairsClock = 0.0;
    bool drawCrosshairs = false;
    float[] crosshairsPos = new float[2];
    Texture2D backgroundSprite;
    SpriteFont gameFont;
    Vector2 targetPosition = new Vector2(600, 400);
    MouseState mouseState;
    Song explosionSong;
    Circle circleTarget;
    Circle circleMouse;

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
        explosionSong = Content.Load<Song>("explosion");
        circleTarget = new Circle { Center = new Vector2(targetPosition.X + targetSprite.Width / 2, targetPosition.Y + targetSprite.Height / 2), Radius = targetSprite.Width / 2 };
        mouseState = Mouse.GetState();
        circleMouse = new Circle { Center = new Vector2(mouseState.X, mouseState.Y), Radius = 10 };
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        mouseState = Mouse.GetState();
        circleMouse.Center = new Vector2(mouseState.X, mouseState.Y);
        float mx = mouseState.X;
        float my = mouseState.Y;
        float tr = targetSprite.Width / 2;
        float tx = targetPosition.X + tr / 2;
        float ty = targetPosition.Y + tr / 2;
        circleTarget.Center = new Vector2(tx, ty);
        if(circleTarget.Intersects(circleMouse) && mouseState.LeftButton == ButtonState.Pressed)
        {
            drawCrosshairs = true;
            crosshairsPos[0] = mx;
            crosshairsPos[1] = my;
            MediaPlayer.Play(explosionSong);
        }
        if(crosshairsClock >= crosshairsTimer)
        {
            crosshairsClock = 0.0;
            drawCrosshairs = false;
            _change_target(targetSprite.Width / 2);
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
    public bool _hovering_target(double mx, double my, double tx, double ty, double tr)
    {
        //float distanceSquared = (mx - tx) * (mx - tx) + (my - ty) * (my - ty);
        //float radiusSquared = tr * tr;

        //return distanceSquared <= radiusSquared;
        double dist = Math.Sqrt(Math.Pow(mx - tx, 2) + Math.Pow(my - ty, 2));
        return dist <= tr;
    }

    protected override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
        _spriteBatch.DrawString(gameFont, "Click The Target", new Vector2(win_width / 2 - gameFont.MeasureString("Click The Target").X / 2, 20), Color.Black);
        _spriteBatch.Draw(targetSprite, new Vector2(targetPosition.X, targetPosition.Y), Color.White);
        if(drawCrosshairs)
        {
            _spriteBatch.Draw(crosshairsSprite, new Vector2(crosshairsPos[0] - 20, crosshairsPos[1] - 20), Color.White);
            crosshairsClock += gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;

        }
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
