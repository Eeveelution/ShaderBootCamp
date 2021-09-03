using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ShaderBootCamp.Engine {
    public class DrawableManager {
        private struct DrawnShadedDrawable {
            public List<RenderTarget2D> RenderTargets;
            public ShadedDrawable       Drawable;
        }
        
        private List<ManagedDrawable> _drawableList = new();

        public void Draw(SpriteBatch batch, GraphicsDevice graphicsDevice) {
            List<DrawnShadedDrawable> drawnShadedDrawables = new();

            for (int i = 0; i != this._drawableList.Count; i++) {
                ManagedDrawable currentDrawable = this._drawableList[i];

                switch (currentDrawable) {
                    case Drawable drawable:
                        drawable.Draw(batch);
                        break;
                    case ShadedDrawable shadedDrawable:
                        DrawnShadedDrawable drawnShadedDrawable = new() {
                            Drawable = shadedDrawable,
                            RenderTargets = shadedDrawable.Draw(batch, graphicsDevice)
                        };

                        drawnShadedDrawables.Add(drawnShadedDrawable);
                        break;
                }
            }

            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            for (int j = 0; j < drawnShadedDrawables.Count; j++) {
                DrawnShadedDrawable currentDrawable = drawnShadedDrawables[j];

                for (int i = 0; i != currentDrawable.RenderTargets.Count; i++) {
                    RenderTarget2D currentTarget = currentDrawable.RenderTargets[i];

                    batch.Draw(currentTarget, currentDrawable.Drawable.Position, currentDrawable.Drawable.ColorOverride);
                }
            }

            batch.End();
        }

        public void Add(ManagedDrawable drawable) => this._drawableList.Add(drawable);
    }
}
