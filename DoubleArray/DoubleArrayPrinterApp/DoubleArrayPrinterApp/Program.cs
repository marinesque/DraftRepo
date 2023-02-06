internal class Program
{
    private static void Main(string[] args)
    {
        double[] numbers = { 1.12f, 0.0034f, 2.8482478327822f };

        ArrayUtils.ArrayPrinter.Print(
            array: numbers,
            count: null,
            convert: null,
            format: (n) => String.Format("{0:F3}", n));
    }
}