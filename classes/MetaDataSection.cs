


public class MetaDataSection
{
    readonly public string Title;

    readonly public string Artist;

    readonly public string Creator;

    readonly public string Version;

    readonly public string Source;

    readonly public string Tags;

    public MetaDataSection(string title, string artist, string creator, string version, string source, string tags)
    {
        Title = title;
        Artist = artist;
        Creator = creator;
        Version = version;
        Source = source;
        Tags = tags;
    }
}