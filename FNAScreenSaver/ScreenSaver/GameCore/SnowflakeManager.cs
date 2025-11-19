using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ScreenSaver.Models;

namespace ScreenSaver.GameCore
{
    /// <summary>
    /// Класс управления снежинками
    /// </summary>
    public class SnowflakeManager
    {
        private readonly Snowflake[] snowflakes;
        private readonly Texture2D snowflakeTexture;
        private readonly int screenWidth;
        private readonly int screenHeight;

        /// <summary>
        /// Конструктор менеджера снежинок
        /// </summary>
        public SnowflakeManager(Texture2D texture, int count, int screenWidth, int screenHeight)
        {
            snowflakeTexture = texture;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            snowflakes = new Snowflake[count];

            for (var i = 0; i < count; i++)
            {
                snowflakes[i] = new Snowflake();
                snowflakes[i].Reset(screenWidth);
            }
        }

        /// <summary>
        /// Обновление состояний снежинок
        /// </summary>
        public void Update(float deltaTime)
        {
            foreach (var flake in snowflakes)
            {
                flake.Update(deltaTime);

                if (flake.Y > screenHeight)
                {
                    flake.Reset(screenWidth);
                }
            }
        }

        /// <summary>
        /// Отрисовка снежинок
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            var origin = new Vector2(snowflakeTexture.Width / 2f, snowflakeTexture.Height / 2f);

            foreach (var flake in snowflakes)
            {
                spriteBatch.Draw(
                    snowflakeTexture,
                    new Vector2(flake.X, flake.Y),
                    null,
                    flake.Color,
                    0f,
                    origin,
                    flake.Scale,
                    SpriteEffects.None,
                    0f
                );
            }
        }
    }
}
