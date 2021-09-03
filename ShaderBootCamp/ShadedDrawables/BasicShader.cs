using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShaderBootCamp.Engine;

namespace ShaderBootCamp.ShadedDrawables {
    public class BasicShader : ShadedDrawable {
        private Texture2D _whiteTexture;
        private Effect    _effect;

        public BasicShader(Texture2D whiteTexture, Effect basicEffect) {
            this._whiteTexture = whiteTexture;
            this._effect       = basicEffect;
        }

        public override List<RenderTarget2D> Draw(SpriteBatch batch, GraphicsDevice graphicsDevice) {
            List<RenderTarget2D> renderTargets = new();

            RenderTarget2D target = new RenderTarget2D(graphicsDevice, 128, 128);

            graphicsDevice.SetRenderTarget(target);
            graphicsDevice.Clear(Color.White);

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, effect: this._effect);

            batch.Draw(this._whiteTexture, new Vector2(0, 0), Color.White);

            batch.End();

            renderTargets.Add(target);

            graphicsDevice.SetRenderTarget(null);

            return renderTargets;
        }
    }
}
