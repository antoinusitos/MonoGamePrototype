using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGamePrototype.Engine
{
    public class UIPanel : Entity
    {
        public Vector2 size { get; set; } = Vector2.Zero;

        private Texture2D whiteRectangle;

        private Rectangle collisionRectangle { get; set; }

        public UIPanel() : base()
        {

        }

        public override void LoadContent(ContentManager content)
        {
            whiteRectangle = new Texture2D(MainGame.instance.GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });

            collisionRectangle = new Rectangle((int)positionX, (int)positionY, (int)size.X, (int)size.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(whiteRectangle, collisionRectangle, color);
        }

        public bool IsInside()
        {
            return collisionRectangle.Contains(InputManager.instance.GetMousePosition());
        }
    }
}
