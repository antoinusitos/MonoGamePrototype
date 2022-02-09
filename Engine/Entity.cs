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
        public float zOrder { get; set; } = 0;
        public float originX { get; set; } = 0;
        public float originY { get; set; } = 0;

        protected Texture2D texture { get; set; } = null;

        public string texturePath { get; set; } = "";

        public Entity()
        {
            originX = originY = Data.TileSize / 2.0f;
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(Data.DataPath + texturePath);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,
                new Vector2(positionX, positionY),
                null,
                Color.White,
                rotation,
                new Vector2(originX, originY),
                new Vector2(scaleX, scaleY),
                SpriteEffects.None,
                zOrder / 100.0f);
        }
    }
}
