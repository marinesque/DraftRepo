namespace ArrayUtils;

public static class ArrayPrinter
{
    public static void Print(IEnumerable<double> array, int? count, Func<double, string>? format = null, Func<double, double>? convert = null)
    {
        var arrayConverted = new List<double>();
        foreach (var a in array)
        {
            double aConverted;
            if (convert != null)
                aConverted = convert(a);
            else aConverted = a;
            arrayConverted.Add(aConverted);
        }
        foreach (var ac in arrayConverted)
        {
            string acFormatted;
            if (format != null)
                acFormatted = format(ac);
            else acFormatted = ac.ToString();
            Console.WriteLine(acFormatted);
        }
    }
}