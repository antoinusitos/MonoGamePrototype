using Microsoft.Xna.Framework.Input;

namespace MonoGamePrototype.Engine
{
    public class InputManager : Manager
    {
        public static InputManager instance { get; set; } = null;

        public override void Initialize()
        {
            instance = this;
        }

        public bool GetKeyboardDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }

        public bool GetGamepadButtonDown(ButtonState button)
        {
            return button == ButtonState.Pressed;
        }
    }
}
