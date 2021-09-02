using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ShaderBootCamp.Engine {
    public abstract class ShadedDrawable : ManagedDrawable {
        public abstract List<RenderTarget2D> Draw();
    }
}
