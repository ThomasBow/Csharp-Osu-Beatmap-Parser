


using System.Text.Json;

public static class Cache
{
    public const int VERSION = 2;

    public static List<Map> GetCachedMaps(string osuMapsPath)
    {
        List<Map> maps = [];
        string[] files = Directory.GetFiles($"{osuMapsPath}/cached", "*.json", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            string key = Path.GetFileNameWithoutExtension(file);

            string json = File.ReadAllText(file);
            Map map = JsonSerializer.Deserialize<Map>(json) ?? throw new Exception("Failed to deserialize map");

            maps.Add(map);
        }

        return maps;
    }

    public static void CacheMaps(List<Map> maps, string osuMapsPath)
    {
        string cachePath = $"{osuMapsPath}/cached";
        Directory.CreateDirectory(cachePath);

        foreach (Map map in maps)
        {
            string json = JsonSerializer.Serialize(map);
            string path = $"{cachePath}/{map.key}.json";
            File.WriteAllText(path, json);
        }
    }
}