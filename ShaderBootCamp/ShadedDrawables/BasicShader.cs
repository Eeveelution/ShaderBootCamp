using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShaderBootCamp.Engine;

namespace ShaderBootCamp.ShadedDrawables {
    public class BasicShader : Drawable {
        private Texture2D _whiteTexture;
        private Effect    _effect;

        public BasicShader(Texture2D whiteTexture, Effect basicEffect) {
            this._whiteTexture = whiteTexture;
            this._effect       = basicEffect;
        }

        public override void Draw(SpriteBatch batch) {
            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, effect: this._effect);

            batch.Draw(this._whiteTexture, new Vector2(0, 0), Color.White);

            batch.End();
        }
    }
}
