


public class MetaDataSection
{
    readonly public string Title = string.Empty;
    readonly public string Artist = string.Empty;
    public const string Creator = "OsuEPAI";
    readonly public string Version = string.Empty;
    readonly public string Source = string.Empty;
    readonly public string Tags = string.Empty;

    public MetaDataSection(string[] lines)
    {
        foreach (string line in lines)
        {
            Debugger.currentLine = line;

            if (string.IsNullOrWhiteSpace(line)) break;

            string[] parts = line.Split(':');

            string key = parts[0].Trim();
            string value = parts[1].Trim();

            switch (key)
            {
                case "Title":
                    Title = value;
                    break;
                case "Artist":
                    Artist = value;
                    break;
                case "Version":
                    Version = value;
                    break;
                case "Source":
                    Source = value;
                    break;
                case "Tags":
                    Tags = value;
                    break;
            }
        }
    }
}