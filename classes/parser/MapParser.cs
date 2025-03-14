




public class OsuMapParser
{
    readonly string osuMapsFolderPath;

    public OsuMapParser(string osuMapsFolderPath)
    {
        this.osuMapsFolderPath = osuMapsFolderPath;
    }

    public IEnumerable<Map> ParseAllMaps(bool useCache = false)
    {
        string[] folders = Directory.GetDirectories(osuMapsFolderPath);

        List<Map> maps = [];
        foreach (string folder in folders)
        {
            string[] osuFiles = Directory.GetFiles(folder, "*.osu", SearchOption.AllDirectories);
            return ParseAllMapsWithoutCache(osuFiles);
        }
        return [];
    }

    private IEnumerable<Map> ParseAllMapsWithoutCache(string[] osuFiles)
    {
        List<Map> parsedMaps = [];

        foreach (var osuFile in osuFiles)
        {
            Map map = ParseMap(osuFile);
            parsedMaps.Add(map);
        }

        return parsedMaps;
    }

    public Map ParseFirst()
    {
        string[] osuFiles = Directory.GetFiles(osuMapsFolderPath, "*.osu", SearchOption.AllDirectories);

        Map map = ParseMap(osuFiles[0]);

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