﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGamePrototype.Engine
{
    public class Level : BaseBehaviour
    {
        public List<Entity> entities { get; set; } = null;

        private ContentManager contentManager { get; set; } = null;

        public Level()
        {
            entities = new List<Entity>();
        }

        public override void Initialize()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Initialize();
            }
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
            for(int i = 0; i < entities.Count; i++)
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

        public void AddEntity(Entity entity, bool useInitAndLoad = true)
        {
            if (entities.Contains(entity))
                return;

            entities.Add(entity);
            if (useInitAndLoad)
            {
                entity.Initialize();
                entity.LoadContent(contentManager);
            }
        }

        public void ClearEntities()
        {
            entities.Clear();
        }
    }
}
