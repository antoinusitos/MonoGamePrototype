using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGamePrototype.Engine
{
    public class UIManager : Manager
    {
        public static UIManager instance { get; private set; } = null;

        public Dictionary<int, List<Entity>> entities { get; set; } = null;

        private ContentManager contentManager { get; set; } = null;

        public override void Initialize()
        {
            instance = this;
            entities = new Dictionary<int, List<Entity>>();
        }

        public override void LoadContent(ContentManager content)
        {
            contentManager = content;
            foreach (KeyValuePair<int, List<Entity>> pair in entities)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    pair.Value[i].LoadContent(content);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<int, List<Entity>> pair in entities)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    if (!pair.Value[i].isActive)
                        continue;

                    pair.Value[i].Update(gameTime);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<int, List<Entity>> pair in entities)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    if (!pair.Value[i].isActive)
                        continue;

                    pair.Value[i].Draw(spriteBatch);
                }
            }
        }

        public void AddEntity(Entity entity)
        {
            entity.Initialize();
            entity.LoadContent(contentManager);
            entities[entity.zOrder].Add(entity);
        }

        public void ClearEntities()
        {
            foreach (KeyValuePair<int, List<Entity>> pair in entities)
            {
                pair.Value.Clear();
            }
        }
    }
}
