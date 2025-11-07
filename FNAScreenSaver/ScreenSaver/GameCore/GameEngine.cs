using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ScreenSaver.Constants;
using Color = Microsoft.Xna.Framework.Color;

namespace ScreenSaver.GameCore
{
    /// <summary>
    /// Игровой движок
    /// </summary>
    public class GameEngine : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch = null!;
        private SnowflakeManager snowflakeManager = null!;

        private Texture2D background = null!;

        /// <summary>
        /// Конструктор движка
        /// </summary>
        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;

            IsMouseVisible = false;
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("Village");
            var snowflakeTexture = Content.Load<Texture2D>("Snowflake");

            var width = GraphicsDevice.Viewport.Width;
            var height = GraphicsDevice.Viewport.Height;

            snowflakeManager = new SnowflakeManager(snowflakeTexture, AppConstants.Count, width, height);
        }


        /// <summary>
        /// Обновление состояния приложения
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            snowflakeManager.Update(deltaTime);

            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                Exit();
            }

            base.Update(gameTime);
        }


        /// <summary>
        /// Отрисовка. Вызывается когда игра готова к отрисовке, вызывается каждым кадром
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            spriteBatch.Begin();

            spriteBatch.Draw(background, GraphicsDevice.Viewport.Bounds, Color.White);

            snowflakeManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
