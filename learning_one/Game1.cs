using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace learning_one;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    int win_width = 900;
    int win_height = 600;
    Texture2D targetSprite;
    Texture2D crosshairsSprite;
    Texture2D backgroundSprite;

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
        //GraphicsDevice.Clear(new Color(18, 53, 36));
        _spriteBatch.Begin();
        GraphicsDevice.Clear(new Color(18, 53, 36));
        _spriteBatch.Draw(targetSprite, new Vector2(0, 0), Color.White);
        _spriteBatch.End();
        //var bg_color = new Color(18, 53, 36);
        //GraphicsDevice.Clear(bg_color); // Phthalo Green color
        base.Draw(gameTime);
    }
}
