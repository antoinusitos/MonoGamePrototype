using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

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

        public Color color { get; set; } = Color.White;

        public string texturePath { get; set; } = "";

        public Rectangle collision { get; set; }

        public bool hasCollision { get; set; } = false;

        public bool isDirty { get; set; } = false;

        public Entity()
        {
            originX = originY = Data.TileSize / 2.0f;
        }

        public override void LoadContent(ContentManager content)
        {
            if(texturePath != "")
            {
                if(File.Exists(Directory.GetCurrentDirectory() + "\\Content\\" + Data.DataPath + texturePath + ".xnb"))
                {
                    texture = content.Load<Texture2D>(Data.DataPath + texturePath);
                }
            }
        }

        public void UpdateTexture(string newTexture, ContentManager content)
        {
            texturePath = newTexture;
            LoadContent(content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (texture == null)
                return;

            spriteBatch.Draw(
                texture,
                new Vector2(positionX, positionY),
                null,
                color,
                rotation,
                new Vector2(originX, originY),
                new Vector2(scaleX, scaleY),
                SpriteEffects.None,
                zOrder / 100.0f);
        }

        public virtual void RevertMovement()
        {
            CleanDirtyFlag();
        }

        public void CleanDirtyFlag()
        {
            isDirty = false;
        }
    }
}
