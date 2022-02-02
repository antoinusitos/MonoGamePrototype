﻿using Microsoft.Xna.Framework.Input;

namespace MonoGamePrototype.Engine
{
    public class InputManager : Manager
    {
        public static InputManager instance { get; set; } = null;

        private KeyboardState previousState { get; set; }
        private KeyboardState currentState { get; set; }

        public override void Initialize()
        {
            instance = this;
        }

        public void Update()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();
        }

        public bool GetKeyboardDown(Keys key)
        {
            return currentState.IsKeyDown(key);
        }

        public bool GetKeyboardUp(Keys key)
        {
            return currentState.IsKeyUp(key);
        }

        public bool GetKeyboardPressed(Keys key)
        {
            return previousState.IsKeyUp(key) && currentState.IsKeyDown(key);
        }

        public bool GetKeyboardReleased(Keys key)
        {
            return currentState.IsKeyUp(key) && previousState.IsKeyDown(key);
        }

        public bool GetGamepadButtonDown(ButtonState button)
        {
            return button == ButtonState.Pressed;
        }
    }
}
