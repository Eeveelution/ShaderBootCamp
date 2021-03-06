using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShaderBootCamp.Engine;

namespace ShaderBootCamp.ShadedDrawables {
    public class PlotLine : Drawable {
        private Texture2D _whiteTexture;
        private Effect    _plotEffect;

        public PlotLine(Texture2D whiteTexture, Effect plotEffect, Vector2 position) {
            this._whiteTexture  = whiteTexture;
            this._plotEffect = plotEffect;

            this.Position = position;
        }

        public override void Draw(GameTime time, SpriteBatch batch) {
            this._plotEffect.Parameters["u_time"]?.SetValue((float)time.TotalGameTime.TotalSeconds);

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, effect: this._plotEffect);
            batch.Draw(this._whiteTexture, this.Position, Color.White);
            batch.End();

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            batch.DrawString(Game1.Instance.ArialFont, "Plotting a Line", this.Position + new Vector2(0, 256), Color.White);

            batch.End();
        }
    }
}
