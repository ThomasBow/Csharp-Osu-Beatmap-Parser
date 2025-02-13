


using System.Text.Json;

public class OsuMapParser
{
    readonly string osuMapsPath;

    public OsuMapParser(string osuMapsPath)
    {
        this.osuMapsPath = osuMapsPath;
    }

    public IEnumerable<MapAndSong> ParseAllMaps(bool useCache = false)
    {
        string[] folders = Directory.GetDirectories(osuMapsPath);

        List<Map> maps = [];
        foreach (string folder in folders)
        {
            string[] files = Directory.GetFiles(folder, "*.osu", SearchOption.AllDirectories);
            if (useCache)
            {
                return ParseAllMapsWithCache(files);
            }
            else
            {
                return ParseAllMapsWithoutCache(files);
            }
        }
        return [];
    }



    private IEnumerable<Map> ParseAllMapsWithCache(string[] files)
    {
        List<Map> parsedMaps = [];

        IEnumerable<Map> cachedMaps = Cache.GetCachedMaps(osuMapsPath)
            .Where(map => map.version == Cache.VERSION);

        foreach (var file in files)
        {
            string key = Path.GetFileNameWithoutExtension(file);

            if (cachedMaps.Any(map => map.key == key))
            {
                continue;
            }

            Map map = ParseMap(file);

            parsedMaps.Add(map);
        }

        Cache.CacheMaps(parsedMaps, osuMapsPath);

        IEnumerable<Map> allMaps = cachedMaps.Concat(parsedMaps);

        return allMaps;
    }

    private IEnumerable<Map> ParseAllMapsWithoutCache(string[] files)
    {
        List<Map> parsedMaps = [];

        foreach (var file in files)
        {
            Map map = ParseMap(file);
            parsedMaps.Add(map);
        }

        return parsedMaps;
    }

    public Map ParseFirst()
    {
        string[] files = Directory.GetFiles(osuMapsPath, "*.osu", SearchOption.AllDirectories);


        Map map = ParseMap(files[0]);

        return map;
    }

    public static Map ParseMap(string osuMapPath)
    {
        Debugger.currentLine = osuMapPath;

        string[] lines = File.ReadAllLines(osuMapPath);

        string key = Path.GetFileNameWithoutExtension(osuMapPath);
        Map map = new(key, lines);
        return map;
    }
}