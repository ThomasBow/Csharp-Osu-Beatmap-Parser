

using System.Globalization;



bool shouldUseCustomPath = false;
bool shouldParseAll = false;
CheckArgs();

try
{
    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
    CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

    string folderPath = shouldUseCustomPath ? GetCustomPath() : Environment.CurrentDirectory + "/osuBeatmaps";


    OsuMapParser parser = new(folderPath);

    IEnumerable<Map> maps;
    if (shouldParseAll)
    {
        maps = parser.ParseAllMaps();
    }
    else
    {
        Map map = parser.ParseFirst();
        maps = [map];
    }
}
catch (Exception e)
{
    Debugger.Log(e);
    return;
}



// METHODS

void CheckArgs()
{
    Dictionary<string, Action> argsMapping = new(){
        { "-custompath", () => shouldUseCustomPath = true },
        { "-parseall", () => shouldParseAll = true }
    };

    foreach (string arg in args)
    {
        string loweredArg = arg.ToLower();
        argsMapping[loweredArg]?.Invoke();
    }
}

string GetCustomPath()
{
    string? customPath = Console.ReadLine()
        ?? throw new Exception("Custom path not provided");
    return customPath;
}

