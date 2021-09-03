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

            this._basicEffect   = this.Content.Load<Effect>("Shaders/basicEffect");
            this._uniformEffect = this.Content.Load<Effect>("Shaders/uniforms");

            BasicShader shader            = new(this._whiteTexture, this._basicEffect,   new Vector2(32, 32));
            UniformsShader uniformsShader = new(this._whiteTexture, this._uniformEffect, new Vector2(32 + 256, 32));

            this._drawableManager.Add(shader);
            this._drawableManager.Add(uniformsShader);
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
