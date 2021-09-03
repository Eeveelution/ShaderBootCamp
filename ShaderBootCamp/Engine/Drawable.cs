using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShaderBootCamp.Engine {
    public abstract class Drawable {
        public Vector2 Position;
        public Color   ColorOverride;
        public float   Rotation;
        public abstract void Draw(GameTime time, SpriteBatch batch);
        public virtual void Update(GameTime time) { }
    }
}
