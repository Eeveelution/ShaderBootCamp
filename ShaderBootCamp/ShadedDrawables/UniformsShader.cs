using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShaderBootCamp.Engine;

namespace ShaderBootCamp.ShadedDrawables {
    public class UniformsShader : Drawable {
        private Texture2D _whiteTexture;
        private Effect    _uniformEffect;

        public UniformsShader(Texture2D whiteTexture, Effect uniformEffect, Vector2 position) {
            this._whiteTexture  = whiteTexture;
            this._uniformEffect = uniformEffect;

            this.Position = position;
        }

        public override void Draw(GameTime time, SpriteBatch batch) {
            this._uniformEffect.Parameters["u_time"].SetValue((float)time.TotalGameTime.TotalSeconds);

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, effect: this._uniformEffect);

            batch.Draw(this._whiteTexture, this.Position, Color.White);

            batch.End();
        }
    }
}
