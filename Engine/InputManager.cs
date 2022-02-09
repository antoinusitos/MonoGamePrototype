using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGamePrototype.Engine
{
    public class InputManager : Manager
    {
        public static InputManager instance { get; set; } = null;

        private KeyboardState previousState { get; set; }
        private KeyboardState currentState { get; set; }

        private MouseState previousMouseState { get; set; }
        private MouseState currentMouseState { get; set; }

        public override void Initialize()
        {
            instance = this;
        }

        public override void Update(GameTime gameTime)
        {
            previousState = currentState;
            currentState = Keyboard.GetState();

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
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

        public Vector2 GetMousePosition()
        {
            return Mouse.GetState().Position.ToVector2();
        }

        public bool GetMouseButtonDown(int index)
        {
            if(index == 0)
                return currentMouseState.LeftButton == ButtonState.Pressed;
            else
                return currentMouseState.RightButton == ButtonState.Pressed;
        }

        public bool GetMouseButtonPressed(int index)
        {
            if (index == 0)
                return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
            else
                return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
        }
    }
}
