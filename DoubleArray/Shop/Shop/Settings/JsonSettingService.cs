using System.Text.Json;

namespace Shop.Settings;

public class JsonSettingService : ISettingService
{
    string _filePath;

    public JsonSettingService(string filePath)
    {
        if (Path.GetExtension(filePath) != ".json")
            throw new ArgumentException(nameof(filePath), "Settings file should be of type JSON!");

        _filePath = filePath;
    }

    public DataBaseSettings Read()
    {
        try
        {
            var jsonString = File.ReadAllText(_filePath);
            var settings = JsonSerializer.Deserialize<DataBaseSettings>(jsonString);
            if (settings is null)
                throw new JsonException($"Couldn't read settings from JSON file {this._filePath}!");
            else
                return settings;
        }
        catch
        {
            return new DataBaseSettings();
        }
    }
}
