


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
        List<MapAndKey> parsedMaps = [];
        string[] files = Directory.GetFiles(osuMapsPath, "*.osu", SearchOption.AllDirectories);

        List<MapAndKey> cachedMaps = Cache.GetCachedMaps(osuMapsPath)
            .Where(mapAndKey => mapAndKey.map.version == Cache.VERSION)
            .ToList();

        foreach (var file in files)
        {
            string key = Path.GetFileNameWithoutExtension(file);

            if (cachedMaps.Any(mapAndKey => mapAndKey.key == key))
            {
                continue;
            }

            Map map = ParseMap(file);

            MapAndKey mapAndKey = new(key, map);
            parsedMaps.Add(mapAndKey);
        }

        Cache.CacheMaps(parsedMaps, osuMapsPath);

        List<MapAndKey> allMaps = cachedMaps.Concat(parsedMaps).ToList();

        return allMaps;
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
}