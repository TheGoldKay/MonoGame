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
        Window.Title = "Mono Snake"; // Set the title of the window
        base.Initialize();
        
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

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
        //GraphicsDevice.Clear(Color.);
        var bg_color = new Color(18, 53, 36);
        GraphicsDevice.Clear(bg_color); // Phthalo Green color
        base.Draw(gameTime);
    }
}
