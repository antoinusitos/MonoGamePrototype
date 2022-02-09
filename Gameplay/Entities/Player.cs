using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;
using System;

namespace MonoGamePrototype.Gameplay.Entities
{
    public class Player : Entity
    {
        private float speed { get; set; } = 0.3f;

        public Player(string path)
        {
            texturePath = path;
        }

        public override void Initialize()
        {
            zOrder = 49;
        }

        public override void Update(GameTime gameTime)
        {
            if (GameManager.instance.currentGameState != GameManager.GameState.GAME)
                return;

            if (InputManager.instance.GetKeyboardDown(Keys.D))
            {
                positionX += gameTime.ElapsedGameTime.Milliseconds * speed;
            }
            else if (InputManager.instance.GetKeyboardDown(Keys.Q))
            {
                positionX -= gameTime.ElapsedGameTime.Milliseconds * speed;
            }

            if (InputManager.instance.GetKeyboardDown(Keys.Z))
            {
                positionY -= gameTime.ElapsedGameTime.Milliseconds * speed;
            }
            else if (InputManager.instance.GetKeyboardDown(Keys.S))
            {
                positionY += gameTime.ElapsedGameTime.Milliseconds * speed;
            }

            Vector2 mousePos = InputManager.instance.GetMousePosition();
        }
    }
}
