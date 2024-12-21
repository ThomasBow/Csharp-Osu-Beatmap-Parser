


public class TimingPoint
{
    readonly public int time;
    readonly public double beatLength;
    readonly public int meter;
    readonly public int sampleSet;
    readonly public int sampleIndex;
    readonly public int volume;
    readonly public bool uninherited;
    readonly public int effects;

    public TimingPoint(int time, double beatLength, int meter, int sampleSet, int sampleIndex, int volume, bool uninherited, int effects)
    {
        this.time = time;
        this.beatLength = beatLength;
        this.meter = meter;
        this.sampleSet = sampleSet;
        this.sampleIndex = sampleIndex;
        this.volume = volume;
        this.uninherited = uninherited;
        this.effects = effects;
    }
}