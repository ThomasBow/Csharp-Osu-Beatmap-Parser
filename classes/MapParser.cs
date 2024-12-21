


public class OsuMapParser
{
    readonly string osuMapsPath;

    public OsuMapParser(string osuMapsPath)
    {
        this.osuMapsPath = osuMapsPath;
    }

    public List<Map> ParseAllMaps()
    {
        List<Map> maps = [];
        string[] files = Directory.GetFiles(osuMapsPath, "*.osu", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var map = ParseMap(file);
            maps.Add(map);
        }

        return maps;
    }

    public Map ParseMap(string osuMapPath)
    {
        string[] lines = File.ReadAllLines(osuMapPath);

        Map map = new(lines);
        return map;
    }

}