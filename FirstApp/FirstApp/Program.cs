using FirstApp;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appConfig.json")
    .Build();

var configurationString = config.GetConnectionString(conn)

do
{
    Console.WriteLine("Enter the key: ");

//var key = Console.ReadKey(true);
//var keyCode = key.Key;
bool exitFlag = false;
//exitFlag = (keyCode == ConsoleKey.Escape);

string strChoice = Console.ReadLine();
int choice;
if (!Int32.TryParse(strChoice, out choice)) break;

switch (choice)
{
    case 1:
        ListClients();
        break;
    case 2:
        AddClient();
        break;
    case 3:
        UpdateClient();
        break;
    case 4:
        DeleteClient();
        break;
    case 0:
        exitFlag = true;
        break;
    default:
        break;
}

if (exitFlag)
{
    try
    {
        using var context = new ApplicationContext();

        context.SaveChanges();
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
} while (true) ;

var client = new Client()
{
    Name = "Рафаэль",
    Email = "GRaf@ya.ru"
};
//AddUser(client);



void ListClients()
{
    Console.WriteLine("ListClients");
    try
    {
        using var context = new ApplicationContext();

        var clients = context.Clients.ToList();
        foreach (var client in clients)
            Console.WriteLine(client);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void AddClient()
{
    Console.WriteLine("AddClient");

    string? name = null;
    do
    {
        Console.Write("Name = ");
        name = Console.ReadLine();
    } while (String.IsNullOrEmpty(name));


    Console.Write("Email = ");
    var email = Console.ReadLine();

    Console.Write("Phone = ");
    var phone = Console.ReadLine();

    var client = new Client()
    {
        Name = name,
        Email = email,
        Phone = phone
    };
    AddUser(client);
}

void UpdateClient()
{
    Console.WriteLine("UpdateClient");

    Console.WriteLine("Name to search = ");
    var name = Console.ReadLine();

    try
    {
        using var context = new ApplicationContext();

        var user = (from client in context.Clients
                    where String.Equals(client.Name, name, StringComparison.InvariantCultureIgnoreCase)
                    select client).FirstOrDefault();

        if (user is null)
        {
            Console.WriteLine("Пользователь не найден");
            return;
        }

        Console.WriteLine("Field to edit? (1 - Name, 2 - Email, 3 - Phone)");
        var strFieldKey = Console.ReadLine();

        int fieldNumber;
        if (!Int32.TryParse(strFieldKey, out fieldNumber))
        {
            Console.WriteLine("Incorrect key");
            return;
        }

        switch (fieldNumber)
        {
            case 1:
                Console.WriteLine("New Name = ");
                var newName = Console.ReadLine();
                user.Name = newName;
                break;
            case 2:
                Console.WriteLine("New Email = ");
                var newEmail = Console.ReadLine();
                user.Email = newEmail;
                break;
            case 3:
                Console.WriteLine("New Phone = ");
                var newPhone = Console.ReadLine();
                user.Phone = newPhone;
                break;
            case 0:
                break;
        }

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void DeleteClient()
{
    Console.WriteLine("DeleteClient");

    Console.WriteLine("Name to search = ");
    var name = Console.ReadLine();

    if (name is null)
    {
        Console.WriteLine("Имя введено некорректно");
        return;
    }

    var client = FindClientByName(name);
}

Client FindClientByName(string name)
{
    Client? user;

    try
    {
        using var context = new ApplicationContext();

        user = (from client in context.Clients
                where String.Equals(client.Name, name, StringComparison.InvariantCultureIgnoreCase)
                select client).FirstOrDefault();


        if (Equals(user, default(Client)))
        {
            Console.WriteLine("Пользователь не найден");
            return new();
        }


        return user;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);

        return new();
    }
}


void AddUser(Client client)
{
    try
    {
        using var context = new ApplicationContext();

        context.Clients.Add(client);
        context.SaveChanges();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}