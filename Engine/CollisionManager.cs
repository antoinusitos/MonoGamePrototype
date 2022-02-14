using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonoGamePrototype.Engine
{
    public class CollisionManager : Manager
    {
        public static CollisionManager instance { get; set; } = null;

        private List<Entity> collidableEntities { get; set; } = new List<Entity>();

        public override void Initialize()
        {
            base.Initialize();

            instance = this;
        }

        public void AddEntity(Entity entity)
        {
            collidableEntities.Add(entity);
        }

        public bool CheckCollision(Entity entity)
        {
            Rectangle entityRectangle = new Rectangle((int)entity.positionX, (int)entity.positionY, Data.TileSize, Data.TileSize);

            for (int i = 0; i < collidableEntities.Count; i++)
            {
                if (collidableEntities[i] == entity)
                    continue;

                Rectangle testRectangle = new Rectangle((int)collidableEntities[i].positionX, (int)collidableEntities[i].positionY, Data.TileSize, Data.TileSize);

                if (entityRectangle.X < testRectangle.X + testRectangle.Width &&
                   entityRectangle.X + entityRectangle.Width > testRectangle.X &&
                   entityRectangle.Y < testRectangle.Y + testRectangle.Height &&
                   entityRectangle.Height + entityRectangle.Y > testRectangle.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            for (int i = 0; i < collidableEntities.Count; i++)
            {
                if(collidableEntities[i].isDirty)
                {
                    if(CheckCollision(collidableEntities[i]))
                    {
                        collidableEntities[i].RevertMovement();
                    }
                    else
                    {
                        collidableEntities[i].CleanDirtyFlag();
                    }
                }
            }
        }
    }
}
