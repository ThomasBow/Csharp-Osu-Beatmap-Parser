


using System.Text.Json;

public static class Cache
{
    public const int VERSION = 1;

    public static List<MapAndKey> GetCachedMaps(string osuMapsPath)
    {
        List<MapAndKey> maps = [];
        string[] files = Directory.GetFiles($"{osuMapsPath}/cached", "*.json", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            string key = Path.GetFileNameWithoutExtension(file);

            string json = File.ReadAllText(file);
            Map map = JsonSerializer.Deserialize<Map>(json) ?? throw new Exception("Failed to deserialize map");

            maps.Add(new(key, map));
        }

        return maps;
    }

    public static void CacheMaps(List<MapAndKey> maps, string osuMapsPath)
    {
        string cachePath = $"{osuMapsPath}/cached";
        Directory.CreateDirectory(cachePath);

        foreach (MapAndKey mapAndKey in maps)
        {
            mapAndKey.map.version = VERSION;
            string json = JsonSerializer.Serialize(mapAndKey.map);
            string path = $"{cachePath}/{mapAndKey.key}.json";
            File.WriteAllText(path, json);
        }
    }
}