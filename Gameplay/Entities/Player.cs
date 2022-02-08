using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;
using System;

namespace MonoGamePrototype.Gameplay.Entities
{
    public class Player : Entity
    {
        private Texture2D texture { get; set; } = null;

        private float speed { get; set; } = 0.3f;

        public override void Initialize()
        {
            zOrder = 1;
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(Data.DataPath + "Hitman 1/hitman1_gun");
        }

        public override void Update(GameTime gameTime)
        {
            if (GameManager.instance.currentGameState != GameManager.GameState.GAME)
                return;

            if (InputManager.instance.GetKeyboardDown(Keys.D))
            {
                position += Vector2.UnitX * gameTime.ElapsedGameTime.Milliseconds * speed;
            }
            else if (InputManager.instance.GetKeyboardDown(Keys.Q))
            {
                position -= Vector2.UnitX * gameTime.ElapsedGameTime.Milliseconds * speed;
            }

            if (InputManager.instance.GetKeyboardDown(Keys.Z))
            {
                position -= Vector2.UnitY * gameTime.ElapsedGameTime.Milliseconds * speed;
            }
            else if (InputManager.instance.GetKeyboardDown(Keys.S))
            {
                position += Vector2.UnitY * gameTime.ElapsedGameTime.Milliseconds * speed;
            }

            Vector2 mousePos = InputManager.instance.GetMousePosition();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
