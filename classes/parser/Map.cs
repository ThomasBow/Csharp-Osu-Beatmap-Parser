



[Serializable]
public class Map
{
    public int version { get; private set; }
    public string key { get; private set; }

    public readonly GeneralSection generalSection;
    //public readonly MetaDataSection metaDataSection;
    public readonly DifficultySection difficultySection;
    public readonly TimingPointsSection timingPointsSection;
    public readonly HitObjectsSection hitObjectsSection;

    public Map(string key, string[] osuMapFileLines)
    {
        version = Cache.VERSION;
        this.key = key;

        GeneralSection? generalSection = null;
        //MetaDataSection? metaDataSection = null;
        DifficultySection? difficultySection = null;
        TimingPointsSection? timingPointsSection = null;
        HitObjectsSection? hitObjectsSection = null;

        for (int i = 0; i < osuMapFileLines.Length; i++)
        {
            string line = osuMapFileLines[i];
            Debugger.currentLine = line;

            if (line.StartsWith('[') == false) continue;

            string[] remainingLines = osuMapFileLines[(i + 1)..];
            if (line.StartsWith("[General]"))
            {
                generalSection = new(remainingLines);
            }
            /*else if (line.StartsWith("[Metadata]"))
            {
                metaDataSection = new(remainingLines);
            }*/
            else if (line.StartsWith("[Difficulty]"))
            {
                difficultySection = new(remainingLines);
            }
            else if (line.StartsWith("[TimingPoints]"))
            {
                timingPointsSection = new(remainingLines);
            }
            else if (line.StartsWith("[HitObjects]"))
            {
                hitObjectsSection = new(remainingLines);
            }
        }

        this.generalSection = generalSection ?? throw new Exception("General section not found");
        //this.metaDataSection = metaDataSection ?? throw new Exception("Metadata section not found");
        this.difficultySection = difficultySection ?? throw new Exception("Difficulty section not found");
        this.timingPointsSection = timingPointsSection ?? throw new Exception("TimingPoints section not found");
        this.hitObjectsSection = hitObjectsSection ?? throw new Exception("HitObjects section not found");
    }
}