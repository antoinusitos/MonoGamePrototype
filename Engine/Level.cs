using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGamePrototype.Engine
{
    public class Level : BaseBehaviour
    {
        protected List<Entity> entities { get; set; } = null;

        private ContentManager contentManager { get; set; } = null;

        protected string levelName { get; set; } = "";

        private bool firstFrame { get; set; } = true;
        private System.Diagnostics.Stopwatch startTime { get; set; } = null;


        public Level(string name)
        {
            levelName = name;
            entities = new List<Entity>();
        }

        public override void Initialize()
        {
            startTime = new System.Diagnostics.Stopwatch();
            startTime.Start();


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

        public override void Start()
        {
            base.Start();

            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Start();
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

            for (int i = 0; i < entities.Count; i++)
            {
                if (!entities[i].isActive)
                    continue;

                entities[i].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < entities.Count; i++)
            {
                if (!entities[i].isActive)
                    continue;

                entities[i].Draw(spriteBatch);
            }
        }

        public void AddEntity(Entity entity)
        {
            entity.Initialize();
            entity.LoadContent(contentManager);
            entities.Add(entity);
        }

        public void ClearEntities()
        {
            entities.Clear();
        }
    }
}
