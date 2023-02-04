namespace ExtendedConsole;

public class BigTextPrinter : IPrinter
{
    #region Consts
    // Файл маппинга:
    // 1 строка - перечисление всех символов
    // 2 строка - 
    // 3 строка - S
    // 4 строка - Y
    // 5 строка - M
    // 6 строка - B
    // 7 строка - O
    // 8 строка - L1
    // 9 строка - 
    // 10 строка - S
    // 11 строка - Y
    // 12 строка - M
    // 12 строка - B
    // 14 строка - O
    // 15 строка - L2
    const string MAPPER_FILE_PATH = "LetterFormat.txt";
    // Высота одной буквы
    const int HEIGHT = 6;
    // Горизонтальный отступ между символами
    const int X_SPACING = 1;
    #endregion Consts

    #region Fields
    string SYMBOLS;

    // Маппинг символов
    private Dictionary<char, (int Left, int Top)[]> _mapperDict = new();

    #endregion Fields

    #region Properties
    public char Symbol { get; set; }
    public ConsoleColor? ForegroundColor { get; set; }
    public ConsoleColor? BackgroundColor { get; set; }
    #endregion Properties

    #region ctor
    public BigTextPrinter(char symbol = '*',
        ConsoleColor? foregroundColor = null,
        ConsoleColor? backgroundColor = null)
    {
        ForegroundColor = foregroundColor;
        BackgroundColor = backgroundColor;
        Symbol = symbol;

        try
        {
            SetupPoints();
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
    }
    #endregion ctor

    #region Methods
    string Color { get; set; }


    public void Write(string text)
    {
        var (xOffset, _) = Console.GetCursorPosition();
        foreach (var letter in text)
        {
            var points = MapLetter(letter);
            xOffset += PrintPoints(points, xOffset);
        }
    }

    public void WriteLine(string text)
    {
        this.Write(text);
        var (_, top) = Console.GetCursorPosition();

    }

    //private (int Left, int Top)[] MapLetter(char letter) => letter switch
    //{
    //    'а' => new[] { (2, 0), (1, 1), (3, 1), (0, 2), (1, 2), (2, 2), (3, 2), (4, 2), (0, 3), (4, 3) },
    //    'б' => new[] { (0, 0), (1, 0), (2, 0), (3, 0), (0, 1), (0, 2), (0, 2), (1, 2), (2, 2), (0, 3), (3, 3), (1, 4), (2, 4), (3, 4) },
    //    _ => new[] { (0, 0) },
    //};

    private (int Left, int Top)[] MapLetter(char letter)
    {
        if (!_mapperDict.ContainsKey(letter))
            return new (int Left, int Top)[] { };
        return _mapperDict[letter];
    }

    private int PrintPoints((int Left, int Top)[] points, int offset)
    {
        var (_, yOffset) = Console.GetCursorPosition();
        foreach (var point in points)
        {
            ConsoleUtils.Write(text: Symbol.ToString(),
                left: point.Left,
                top: point.Top,
                foregroundColor: ForegroundColor,
                backgroundColor: BackgroundColor
                );

            if (point.Left > offset)
                offset = point.Left;
        }

        offset += 1 + X_SPACING;

        ConsoleUtils.ShiftCursorPosition(leftShift: offset);

        return offset;
    }

    // Чтение символов из файла
    // FormatException - ошибка при некорректном файле
    private void SetupPoints()
    {
        using var reader = File.OpenText(MAPPER_FILE_PATH);

        var symbols = reader.ReadLine();
        reader.ReadLine();

        if (symbols is null)
            throw new FormatException("Не задан маппер форматирования!");

        // Перебираем символы и читаем их
        foreach (var symbol in SYMBOLS)
        {
            List<(int Left, int Top)> points = new();
            for (var j = 0; j < HEIGHT; j++)
            {
                // Читаем строку
                var str = reader.ReadToEnd();
                // Пустые строки пропускаем
                if (String.IsNullOrEmpty(str))
                    continue;
                // Читаем символы в строке
                for (var i = 0; i < str.Length; i++)
                {
                    if (str[i] != '*')
                        continue;
                    points.Add((i, j));
                }
            }
            // Добавляем символ в словарь
            _mapperDict.Add(symbol, points.ToArray());
        }
    }
    #endregion Methods
}
