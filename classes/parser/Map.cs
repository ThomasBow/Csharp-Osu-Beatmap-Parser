


using Tensorflow.NumPy;

public class Map : ITrainingData
{
    public readonly GeneralSection? generalSection;
    public readonly MetaDataSection? metaDataSection;
    public readonly DifficultySection? difficultySection;
    public readonly TimingPointsSection? timingPointsSection;
    public readonly HitObjectsSection? hitObjectsSection;

    public Map(string[] osuMapFileLines)
    {
        for (int i = 0; i < osuMapFileLines.Length; i++)
        {
            string line = osuMapFileLines[i];
            if (line.StartsWith('[') == false) continue;

            string[] remainingLines = osuMapFileLines[(i + 1)..];
            if (line.StartsWith("[General]"))
            {
                generalSection = new(remainingLines);
            }
            else if (line.StartsWith("[Metadata]"))
            {
                metaDataSection = new(remainingLines);
            }
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
    }

    public NDArray X()
    {
        throw new NotImplementedException();
    }

    public NDArray Y()
    {
        throw new NotImplementedException();
    }
}