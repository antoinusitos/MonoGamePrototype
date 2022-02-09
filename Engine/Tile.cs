using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGamePrototype.Engine
{
    public class Tile : Entity
    {
        public Tile(string path = "")
        {
            texturePath = path;
            zOrder = 0;
        }

        public Tile()
        {
            texturePath = "";
            zOrder = 0;
        }
    }
}
