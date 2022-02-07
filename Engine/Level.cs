using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGamePrototype.Engine
{
    public class Level : BaseBehaviour
    {
        public Dictionary<int, List<Entity>> entities { get; set; } = null;

        private ContentManager contentManager { get; set; } = null;

        protected string levelName { get; set; } = "";

        private bool firstFrame { get; set; } = true;
        private System.Diagnostics.Stopwatch startTime { get; set; } = null;


        public Level(string name)
        {
            levelName = name;
            entities = new Dictionary<int, List<Entity>>
            {
                { 0, new List<Entity>() },
                { 1, new List<Entity>() },
                { 2, new List<Entity>() },
                { 3, new List<Entity>() }
            };
        }

        public override void Initialize()
        {
            startTime = new System.Diagnostics.Stopwatch();
            startTime.Start();

            foreach (KeyValuePair<int, List<Entity>> pair in entities)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    pair.Value[i].Initialize();
                }
            }
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

        public override void Start()
        {
            base.Start();

            foreach (KeyValuePair<int, List<Entity>> pair in entities)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    pair.Value[i].Start();
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if(firstFrame)
            {
                startTime.Stop();
                Console.WriteLine($"{levelName} start Time: {startTime.ElapsedMilliseconds} ms");
                firstFrame = false;
            }

            foreach (KeyValuePair<int, List<Entity>> pair in entities)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    pair.Value[i].Update(gameTime);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach(KeyValuePair<int, List<Entity>> pair in entities)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
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
