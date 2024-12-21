


public class Map
{
    readonly public GeneralSection generalSection;
    readonly public MetaDataSection metaDataSection;
    readonly public DifficultySection difficultySection;
    readonly public TimingPointsSection timingPointsSection;
    readonly public HitObjectsSection hitObjectsSection;

    public Map(string[] osuMapFileLines)
    {
        for (int i = 0; i < osuMapFileLines.Length; i++)
        {
            string line = osuMapFileLines[i];

            if (line.StartsWith("[General]"))
            {
                generalSection = new();
            }
            else if (line.StartsWith("[Metadata]"))
            {
                metaDataSection = new();
            }
            else if (line.StartsWith("[Difficulty]"))
            {
                difficultySection = new();
            }
            else if (line.StartsWith("[HitObjects]"))
            {
                hitObjectsSection = new();
            }
            else if (line.StartsWith("[TimingPoints]"))
            {
                timingPointsSection = new();
            }
        }
    }
}