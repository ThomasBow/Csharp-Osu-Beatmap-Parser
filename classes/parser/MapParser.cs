


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



    private IEnumerable<MapAndSong> ParseAllMapsWithCache(string[] files)
    {
        List<MapAndSong> parsedMaps = [];

        IEnumerable<MapAndSong> cachedMaps = Cache.GetCachedMaps(osuMapsPath)
            .Where(mapAndSong => mapAndSong.Map.version == Cache.VERSION);

        foreach (var file in files)
        {
            string key = Path.GetFileNameWithoutExtension(file);

            if (cachedMaps.Any(mapAndSong => mapAndSong.Map.key == key))
            {
                continue;
            }

            MapAndSong mapAndSong = ParseMap(file);

            parsedMaps.Add(mapAndSong);
        }

        Cache.CacheMaps(parsedMaps, osuMapsPath);

        IEnumerable<MapAndSong> allMaps = cachedMaps.Concat(parsedMaps);

        return allMaps;
    }

    private IEnumerable<MapAndSong> ParseAllMapsWithoutCache(string[] files)
    {
        List<MapAndSong> parsedMaps = [];

        foreach (var file in files)
        {
            MapAndSong mapAndSong = ParseMap(file);
            parsedMaps.Add(mapAndSong);
        }

        return parsedMaps;
    }

    public MapAndSong ParseFirst()
    {
        string[] files = Directory.GetFiles(osuMapsPath, "*.osu", SearchOption.AllDirectories);


        MapAndSong mapAndSong = ParseMap(files[0]);

        return mapAndSong;
    }

    public static MapAndSong ParseMap(string osuMapPath)
    {
        Debugger.currentLine = osuMapPath;

        string[] lines = File.ReadAllLines(osuMapPath);

        string key = Path.GetFileNameWithoutExtension(osuMapPath);
        Map map = new(key, lines);

        SongData songData = new(osuMapPath);

        return new(map, songData);
    }
}