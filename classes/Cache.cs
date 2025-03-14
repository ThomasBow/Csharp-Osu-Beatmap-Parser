


using System.Text.Json;

public static class Cache
{
    public const int VERSION = 2;

    public static List<MapAndSong> GetCachedMaps(string osuMapsPath)
    {
        List<MapAndSong> maps = [];
        string[] files = Directory.GetFiles($"{osuMapsPath}/cached", "*.json", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            string key = Path.GetFileNameWithoutExtension(file);

            string json = File.ReadAllText(file);
            MapAndSong parsed = JsonSerializer.Deserialize<MapAndSong>(json) ?? throw new Exception("Failed to deserialize map");

            maps.Add(parsed);
        }

        return maps;
    }

    public static void CacheMaps(List<MapAndSong> mapAndSongs, string osuMapsPath)
    {
        string cachePath = $"{osuMapsPath}/cached";
        Directory.CreateDirectory(cachePath);

        foreach (MapAndSong mapAndSong in mapAndSongs)
        {
            string json = JsonSerializer.Serialize(mapAndSong);
            string path = $"{cachePath}/{mapAndSong.Map.key}.json";
            File.WriteAllText(path, json);
        }
    }
}