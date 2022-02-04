using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGamePrototype.Engine
{
    public class BaseBehaviour
    {
        protected bool isStarted { get; set; } = false;

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent(ContentManager content)
        {

        }

        public virtual void Start()
        {
            isStarted = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            if(!isStarted)
            {
                Start();
            }    
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
