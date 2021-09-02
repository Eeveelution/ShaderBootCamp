using Microsoft.Xna.Framework.Graphics;

namespace ShaderBootCamp.Engine {
    public abstract class Drawable : ManagedDrawable {
        public abstract void Draw(SpriteBatch batch);
    }
}
