using ExtendedConsole;

ConsoleUtils.Write(
    text: "Всем привет",
    backgroundColor: ConsoleColor.Green,
    foregroundColor: ConsoleColor.Red,
    top: 20,
    left: 30);

Console.ReadLine();

IPrinter printer = new BigTextPrinter();
printer.WriteLine(text: "Текст");

