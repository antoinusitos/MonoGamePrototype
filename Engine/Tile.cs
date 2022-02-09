namespace MonoGamePrototype.Engine
{
    public class Tile : Entity
    {
        public Tile(string path = "") : base()
        {
            texturePath = path;
            zOrder = 0;
        }

        public Tile() : base()
        {
            texturePath = "";
            zOrder = 0;
        }
    }
}
