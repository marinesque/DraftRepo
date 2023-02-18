using System.Xml.Serialization;

namespace Shop.Settings;

internal class XmlSettingsService : ISettingService
{
    string _filePath;

    public XmlSettingsService(string filePath)
    {
        if (Path.GetExtension(filePath) != ".xml")
            throw new ArgumentException(nameof(filePath), "Settings file should be of type XML!");

        _filePath = filePath;
    }
    public DataBaseSettings Read()
    {
        var xml = new XmlSerializer(typeof(DataBaseSettings));
        using var fs = new FileStream(_filePath, FileMode.OpenOrCreate);
        var settings = xml.Deserialize(fs);
        if (settings is not DataBaseSettings dbs)
            throw new ApplicationException($"Couldn't read settings from XML file {this._filePath}!");
        else
            return dbs;
    }
}
