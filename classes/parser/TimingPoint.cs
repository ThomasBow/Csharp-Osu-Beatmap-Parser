


public class TimingPoint
{

    public enum SampleSet
    {
        Auto = 0,
        Normal = 1,
        Soft = 2,
        Drum = 3
    }

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
    readonly public SampleSet sampleSet;
    const int sampleIndex = 0;
    readonly public int volume;
    readonly public bool uninherited;
    readonly public Effects effects;

    public TimingPoint(string line)
    {
        string[] parts = line.Split(',');

        time = int.Parse(parts[0]);
        beatLength = double.Parse(parts[1]);
        meter = int.Parse(parts[2]);
        sampleSet = (SampleSet)int.Parse(parts[3]);

        volume = int.Parse(parts[5]);
        uninherited = int.Parse(parts[6]) > 0;
        effects = (Effects)int.Parse(parts[7]);
    }
}