using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ShaderBootCamp.Engine {
    public class DrawableManager {
        private List<Drawable> _drawableList = new();

        public void Draw(SpriteBatch batch) {

            for (int i = 0; i != this._drawableList.Count; i++) {
                Drawable currentDrawable = this._drawableList[i];

                currentDrawable.Draw(batch);
            }
        }

        public void Add(Drawable drawable) => this._drawableList.Add(drawable);
    }
}
