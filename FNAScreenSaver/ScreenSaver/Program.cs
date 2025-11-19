using ScreenSaver.GameCore;

namespace ScreenSaver
{
    /// <summary>
    /// Класс запуска программы
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Точка входа программы
        /// </summary>
        public static void Main(string[] args)
        {
            using (var game = new GameEngine())
            {
                game.Run();
            }
        }
    }

}
