﻿using Microsoft.Xna.Framework;
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

    public class EntityText : Entity
    {
        public string text { get; set; } = "";

        public TextAlign textAlign { get; set; } = TextAlign.LEFT;

        private SpriteFont font { get; set; } = null;

        public Color color { get; set; } = Color.White;

        public bool isLoaded { get; private set; } = false;

        public EntityText(string aText)
        {
            text = aText;
        }

        public override void LoadContent(ContentManager content)
        {
            isLoaded = true;
            font = content.Load<SpriteFont>(Data.DataPath + "Font/Roboto-Bold-Title");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
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
            spriteBatch.End();
        }
    }
}
