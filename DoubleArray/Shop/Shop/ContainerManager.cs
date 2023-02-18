using Shop.Logger;
using Shop.Settings;

namespace Shop;

public class ContainerManager
{
    public ISettingService SettingService { get; set; }
    public ILogger Logger { get; set; }

    public ContainerManager()
    {
        Logger = new FileLogger("logs.txt"); // new ConsoleLogger();
        SettingService = new XmlSettingsService("settings.xml"); // new JsonSettingsService("settings.json");
    }
}
