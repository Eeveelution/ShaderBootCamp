using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShaderBootCamp.Engine;

namespace ShaderBootCamp.ShadedDrawables {
    public class MouseShader : Drawable {
        private Texture2D _whiteTexture;
        private Effect    _uniformEffect;

        public MouseShader(Texture2D whiteTexture, Effect uniformEffect, Vector2 position) {
            this._whiteTexture  = whiteTexture;
            this._uniformEffect = uniformEffect;

            this.Position = position;
        }

        public override void Draw(GameTime time, SpriteBatch batch) {
            this._uniformEffect.Parameters["mousePos"].SetValue(Game1.Instance.MousePosition);
            this._uniformEffect.Parameters["windowSize"].SetValue(new Vector2(1280, 720));

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, effect: this._uniformEffect);
            batch.Draw(this._whiteTexture, this.Position, Color.White);
            batch.End();

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            batch.DrawString(Game1.Instance.ArialFont, "Taking in Mouse Position", this.Position + new Vector2(0, 256), Color.White);

            batch.End();
        }
    }
}
