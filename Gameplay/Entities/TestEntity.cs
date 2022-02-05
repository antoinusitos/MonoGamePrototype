using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGamePrototype.Engine;
using Microsoft.Xna.Framework.Input;

namespace MonoGamePrototype.Gameplay.Entities
{
    public class TestEntity : Entity
    {
        private Texture2D texture { get; set; } = null;

        private float speed { get; set; } = 0.5f;

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(Data.DataPath + "Tiles/tile_01");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
