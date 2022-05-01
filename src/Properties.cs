using System.Text.Json;
public class Properties
{
    public string Theme { get; set; } = "light";
    public string Env { get; set; } = "dev";
    
    private static string fileName = 
    Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "Teste",
        "config.json"
    );

    public static Properties? GetProperties()
    {
        using (FileStream sr = File.Open(fileName, System.IO.FileMode.Open))
        {
            return JsonSerializer.Deserialize<Properties>(sr);
        }
    }

    public override string ToString()
    {
        return File.ReadAllText(fileName);
    }
}