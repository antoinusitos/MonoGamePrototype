using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGamePrototype.Engine
{
    public enum TextAlign
    {
        LEFT,
        CENTER,
        RIGHT
    }

    public enum TextType
    {
        NORMAL,
        TITLE,
        BOLD
    }


    public class EntityText : Entity
    {
        public string text { get; set; } = "";

        public TextAlign textAlign { get; set; } = TextAlign.LEFT;

        private SpriteFont font { get; set; } = null;

        public TextType textType { get; set; } = TextType.NORMAL;

        public bool isLoaded { get; private set; } = false;

        public EntityText(string aText) : base()
        {
            text = aText;
            zOrder = Data.UIZOrderStart;
        }

        public override void LoadContent(ContentManager content)
        {
            isLoaded = true;
            switch(textType)
            {
                case TextType.TITLE:
                    font = content.Load<SpriteFont>(Data.DataPath + "Font/Roboto-Bold-Title");
                    break;

                case TextType.BOLD:
                    font = content.Load<SpriteFont>(Data.DataPath + "Font/Roboto-Bold");
                    break;

                case TextType.NORMAL:
                    font = content.Load<SpriteFont>(Data.DataPath + "Font/Roboto-Regular");
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 pos = new Vector2(positionX, positionY);
            switch(textAlign)
            {
                case TextAlign.CENTER:
                    Vector2 temp = font.MeasureString(text);
                    pos.X -= temp.X / 2;
                    break;

                case TextAlign.RIGHT:
                    Vector2 tempRight = font.MeasureString(text);
                    pos.X -= tempRight.X;
                    break;
            }
            spriteBatch.DrawString(font, text, pos, color);
        }
    }
}
