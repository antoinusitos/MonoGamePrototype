﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;

namespace MonoGamePrototype.Gameplay.Entities
{
    public class Player : Entity
    {
        private float speed { get; set; } = 0.3f;

        public Player(string path) : base()
        {
            texturePath = path;
            originX = 15;
            originY = 21;
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

            LookAtCursor();
        }

        private void LookAtCursor()
        {
            Vector2 mousePos = InputManager.instance.GetMousePosition();
            mousePos = Data.ScreenToWorldSpace(mousePos);
            Vector2 pos = new Vector2(positionX, positionY);
            Vector2 dir = mousePos - pos;
            dir.Normalize();
            float dot = Vector2.Dot(Vector2.UnitX, dir);

            float toAdd = 0;
            if (mousePos.Y < positionY)
            {
                dot += 1;
                toAdd += 180;
            }
            else
            {
                dot *= -1;
                dot += 1;
            }

            rotation = MathHelper.ToRadians((dot * 90) + toAdd);
        }
    }
}
