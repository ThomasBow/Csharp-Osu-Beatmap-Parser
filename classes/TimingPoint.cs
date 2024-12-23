


public class TimingPoint
{
    [Flags]
    public enum Effects
    {
        None = 0,
        Kiai = 1 << 0,
        OmitFirstBarLine = 1 << 3
    }

    readonly public int time;
    readonly public double beatLength;
    readonly public int meter;
    readonly public int sampleSet;
    readonly public int sampleIndex;
    readonly public int volume;
    readonly public bool uninherited;
    readonly public Effects effects;

    public TimingPoint(string line)
    {
        string[] parts = line.Split(',');

        time = int.Parse(parts[0]);
        beatLength = double.Parse(parts[1]);
        meter = int.Parse(parts[2]);
        sampleSet = int.Parse(parts[3]);
        sampleIndex = int.Parse(parts[4]);
        volume = int.Parse(parts[5]);
        uninherited = int.Parse(parts[6]) > 0;
        effects = (Effects)int.Parse(parts[7]);
    }
}