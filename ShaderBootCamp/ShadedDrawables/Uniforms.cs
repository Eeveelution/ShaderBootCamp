using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShaderBootCamp.Engine;

namespace ShaderBootCamp.ShadedDrawables {
    public class Uniforms : Drawable {
        private Texture2D _whiteTexture;
        private Effect    _uniformEffect;

        public Uniforms(Texture2D whiteTexture, Effect uniformEffect, Vector2 position) {
            this._whiteTexture  = whiteTexture;
            this._uniformEffect = uniformEffect;

            this.Position = position;
        }

        public override void Draw(SpriteBatch batch) {
            this._uniformEffect.Parameters["u_time"
        }
    }
}
