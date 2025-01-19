


using System.Text.Json;

public class OsuMapParser
{
    readonly string osuMapsPath;

    public OsuMapParser(string osuMapsPath)
    {
        this.osuMapsPath = osuMapsPath;
    }

    public List<MapAndKey> ParseAllMaps()
    {
        List<MapAndKey> maps = [];
        string[] files = Directory.GetFiles(osuMapsPath, "*.osu", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            Map map = ParseMap(file);
            string key = Path.GetFileNameWithoutExtension(file);

            MapAndKey mapAndKey = new(key, map);
            maps.Add(mapAndKey);
        }

        return maps;
    }

    public MapAndKey ParseFirst()
    {
        string[] files = Directory.GetFiles(osuMapsPath, "*.osu", SearchOption.AllDirectories);

        Map map = ParseMap(files[0]);
        string key = Path.GetFileNameWithoutExtension(files[0]);

        MapAndKey mapAndKey = new(key, map);
        return mapAndKey;
    }

    public Map ParseMap(string osuMapPath)
    {
        Debugger.currentLine = osuMapPath;

        string[] lines = File.ReadAllLines(osuMapPath);

        Map map = new(lines);
        return map;
    }

    public void CacheMaps(List<MapAndKey> maps)
    {
        foreach (MapAndKey mapAndKey in maps)
        {
            string json = JsonSerializer.Serialize(mapAndKey.map);
            string path = $"{osuMapsPath}/cached/{mapAndKey.key}.json";
            File.WriteAllText(path, json);
        }
    }

    private MapAndKey? GetMapIfChached(string key)
    {
        string path = $"{osuMapsPath}/cached/{key}.json";

        MapAndKey? mapAndKey = null;
        if (File.Exists(path))
        {
            mapAndKey = GetCachedMap(path, key);
        }
        return mapAndKey;
    }

    private MapAndKey GetCachedMap(string path, string key)
    {
        string json = File.ReadAllText(path);
        Map map = JsonSerializer.Deserialize<Map>(json) ?? throw new Exception("Failed to deserialize map");
        MapAndKey mapAndKey = new(key, map);
        return mapAndKey;
    }
}