using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGamePrototype.Engine
{
    public class UIManager : Manager
    {
        public static UIManager instance { get; private set; } = null;

        public List<Entity> entities { get; private set; } = null;

        private ContentManager contentManager { get; set; } = null;

        public override void Initialize()
        {
            instance = this;
            entities = new List<Entity>();
        }

        public override void LoadContent(ContentManager content)
        {
            contentManager = content;
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].LoadContent(content);
            }
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(spriteBatch);
            }
        }

        public void AddEntity(Entity entity)
        {
            if (entities.Contains(entity))
                return;

            entities.Add(entity);
            entity.Initialize();
            entity.LoadContent(contentManager);
        }
    }
}
