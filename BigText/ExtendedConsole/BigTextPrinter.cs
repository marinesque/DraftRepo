namespace ExtendedConsole;

public class BigTextPrinter : IPrinter
{
    #region Properties
    public char Symbol;
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
    }
    #endregion ctor

    #region Methods
    string Color { get; set; }


    public void Write(string text)
    {
        foreach (var letter in text)
        {

        }
    }

    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }

    private int PrintLetter(char letter) => letter switch
    {
        'a' => 0,
        'b' => 1,
        _ => 0,
    };
    #endregion Methods
}
