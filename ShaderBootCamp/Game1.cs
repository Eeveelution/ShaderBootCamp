using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShaderBootCamp.Engine;
using ShaderBootCamp.ShadedDrawables;

namespace ShaderBootCamp {
    public class Game1 : Game {
        public static Game1 Instance;

        public  GraphicsDeviceManager Graphics;
        private Color                 _clearColor = new Color(24, 24, 24);

        private SpriteBatch           _spriteBatch;

        private DrawableManager _drawableManager = new();

        //Common Content for Effects
        private Texture2D  _whiteTexture;
        public  SpriteFont ArialFont;

        //Content for Basic Effect
        private Effect _basicEffect;
        //Content for Uniform Effect
        private Effect _uniformEffect;
        //Content for Texture Coordinate Effect
        private Effect _texCoordEffect;
        //Content for Mouse Position Effect
        private Effect _mousePosEffect;
        //Content for the Plot Line Effect
        private Effect _plotLineEffect;
        private Effect _plotLineShapedEffect;

        public Vector2 MousePosition {
            get {
                (int x, int y) = Mouse.GetState(this.Window).Position;
                return new Vector2(x, y);
            }
        }

        public Game1() {
            this.Graphics             = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible        = true;

            Instance = this;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            this.Graphics.PreferredBackBufferWidth  = 1280;
            this.Graphics.PreferredBackBufferHeight = 720;

            this.Graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            this._whiteTexture = this.Content.Load<Texture2D>("white");
            this.ArialFont     = this.Content.Load<SpriteFont>("Arial");

            this._basicEffect          = this.Content.Load<Effect>("Shaders/basicEffect");
            this._uniformEffect        = this.Content.Load<Effect>("Shaders/uniforms");
            this._texCoordEffect       = this.Content.Load<Effect>("Shaders/texCoord");
            this._mousePosEffect       = this.Content.Load<Effect>("Shaders/mousePos");
            this._plotLineEffect       = this.Content.Load<Effect>("Shaders/plotLine");
            this._plotLineShapedEffect = this.Content.Load<Effect>("Shaders/plotLineShaped");

            BasicShader shader                     = new(this._whiteTexture, this._basicEffect,          new Vector2(32, 32));
            UniformsShader uniformsShader          = new(this._whiteTexture, this._uniformEffect,        new Vector2(32 + 256, 32));
            TextureCoordinateShader texCoordShader = new(this._whiteTexture, this._texCoordEffect,       new Vector2(32 + (256 * 2), 32));
            MouseShader mouseShader                = new(this._whiteTexture, this._mousePosEffect,       new Vector2(32 + (256 * 3), 32));
            PlotLine plotLineShader                = new(this._whiteTexture, this._plotLineEffect,       new Vector2(32, 320));
            PlotLine plotLineShapedShader          = new(this._whiteTexture, this._plotLineShapedEffect, new Vector2(32 + 256, 320));

            this._drawableManager.Add(shader);
            this._drawableManager.Add(uniformsShader);
            this._drawableManager.Add(texCoordShader);
            this._drawableManager.Add(mouseShader);
            this._drawableManager.Add(plotLineShader);
            this._drawableManager.Add(plotLineShapedShader);
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            this._drawableManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(this._clearColor);

            this._drawableManager.Draw(gameTime, this._spriteBatch);

            base.Draw(gameTime);
        }
    }
}
