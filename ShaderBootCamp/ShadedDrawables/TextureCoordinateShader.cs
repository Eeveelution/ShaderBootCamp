using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShaderBootCamp.Engine;

namespace ShaderBootCamp.ShadedDrawables {
    public class TextureCoordinateShader : Drawable {
        private Texture2D _whiteTexture;
        private Effect    _effect;

        public TextureCoordinateShader(Texture2D whiteTexture, Effect textureCoordinateShader, Vector2 position) {
            this._whiteTexture = whiteTexture;
            this._effect       = textureCoordinateShader;

            this.Position = position;
        }
        public override void Draw(GameTime time, SpriteBatch batch) {
            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, effect: this._effect);
            batch.Draw(this._whiteTexture, this.Position, Color.White);
            batch.End();

            //Draw Text LOL

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            batch.DrawString(Game1.Instance.ArialFont, "Taking in Texture Coordinates", this.Position + new Vector2(0, 256), Color.White);
            batch.End();
        }
    }
}
