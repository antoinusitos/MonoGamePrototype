using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGamePrototype.Engine
{
    public class SceneManager : Manager
    {
        public static SceneManager instance { get; set; } = null;

        private Level currentLevel { get; set; } = null;

        private ContentManager contentManager { get; set; } = null;

        public void SetLevel(Level aLevel, bool useInit = true)
        {
            currentLevel = aLevel;
            if (!useInit)
                return;
            currentLevel.Initialize();
            currentLevel.LoadContent(contentManager);
        }

        public override void Initialize()
        {
            instance = this;
        }

        public override void LoadContent(ContentManager content)
        {
            contentManager = content;

            if (currentLevel != null)
                currentLevel.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            if (currentLevel != null)
                currentLevel.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (currentLevel != null)
                currentLevel.Draw(spriteBatch);
        }
    }
}
