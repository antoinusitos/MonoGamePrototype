using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGamePrototype.Engine
{
    public class Entity : BaseBehaviour
    {
        public bool isActive { get; set; } = true;
        public float positionX { get; set; } = 0;
        public float positionY { get; set; } = 0;
        public float rotation { get; set; } = 0;
        public float scaleX { get; set; } = 1;
        public float scaleY { get; set; } = 1;
        public int zOrder { get; set; } = 0;
    }
}
