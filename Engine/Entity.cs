using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGamePrototype.Engine
{
    public class Entity
    {
        public bool isActive { get; set; } = true;
        public Vector2 position { get; set; } = Vector2.Zero;
        public Vector2 rotation { get; set; } = Vector2.Zero;
        public Vector2 scale { get; set; } = Vector2.One;

        public void Initialize()
        {

        }

        public virtual void LoadContent(ContentManager content)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
