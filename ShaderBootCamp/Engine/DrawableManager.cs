using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShaderBootCamp.Engine {
    public class DrawableManager {
        private List<Drawable> _drawableList = new();

        public void Draw(GameTime time, SpriteBatch batch) {
            for (int i = 0; i != this._drawableList.Count; i++) {
                Drawable currentDrawable = this._drawableList[i];

                currentDrawable.Draw(time, batch);
            }
        }

        public void Update(GameTime time) {
            for (int i = 0; i != this._drawableList.Count; i++) {
                Drawable currentDrawable = this._drawableList[i];

                currentDrawable.Update(time);
            }
        }

        public void Add(Drawable drawable) => this._drawableList.Add(drawable);
    }
}
