namespace ExtendedConsole
{
    public static class ConsoleUtils
    {
        public static void Write(string text,
            int? left = null, int? top = null,
            ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            var (curLeft, curTop) = Console.GetCursorPosition();
            left ??= curLeft;
            top ??= curTop;

            //Если не указан кастомный цвет - оставляем текущий
            var curForegroundColor = Console.ForegroundColor;
            foregroundColor ??= curForegroundColor;

            var curBackgroundColor = Console.BackgroundColor;
            backgroundColor ??= curBackgroundColor;

            //Устанавливаем позицию и цвет
            Console.SetCursorPosition(left.Value, top.Value);

            Console.BackgroundColor = backgroundColor.Value;
            Console.ForegroundColor = foregroundColor.Value;

            Console.WriteLine(text);

            //Восстанавливаем старые настройки консоли
            Console.BackgroundColor = curBackgroundColor;
            Console.ForegroundColor = curForegroundColor;
            Console.SetCursorPosition(curLeft, curTop);
        }
    }
}