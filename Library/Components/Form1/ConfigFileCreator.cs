using System.IO;
using System.Xml.Linq;

public static class ConfigFileCreator
{
    public static  void CreateConfigFile(string host, string database, string username, string password)
    {
        XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("configuration",
                new XElement("connectionStrings",
                    new XElement("add",
                        new XAttribute("name", "DefaultConnection"),
                        new XAttribute("connectionString", "Host=; Database=; Username=; Password="),
                        new XAttribute("providerName", "System.Data.SqlClient")
                    )
                ),
                new XElement("appSettings",
                    new XElement("add",
                        new XAttribute("key", "GoogleCustomSearchApiKey"),
                        new XAttribute("value", "")
                    ),
                    new XElement("add",
                        new XAttribute("key", "GoogleCustomSearchCx"),
                        new XAttribute("value", "")
                    )
                )
            )
        );

        string directoryPath = Path.Combine("Library", "Data");
        Directory.CreateDirectory(directoryPath);

        string filePath = Path.Combine(directoryPath, "App.config");
        doc.Save(filePath);
    }
}