using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGamePrototype.Engine
{
    public class Level
    {
        public List<Entity> entities { get; set; } = null;

        public Level()
        {
            entities = new List<Entity>();
        }

        public virtual void Initialize()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Initialize();
            }
        }

        public virtual void LoadContent(ContentManager content)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].LoadContent(content);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            for(int i = 0; i < entities.Count; i++)
            {
                entities[i].Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(spriteBatch);
            }
        }
    }
}
