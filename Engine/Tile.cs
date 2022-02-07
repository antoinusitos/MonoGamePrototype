using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGamePrototype.Engine
{
    public class Tile : Entity
    {
        private Texture2D texture { get; set; } = null;

        private string tilePath { get; set; } = "";

        public Tile(string path)
        {
            tilePath = path;
            zOrder = 0;
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(Data.DataPath + tilePath);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
