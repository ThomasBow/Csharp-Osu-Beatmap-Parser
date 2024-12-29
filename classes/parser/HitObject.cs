


public class HitObject
{
    [Flags]
    public enum HitObjectType
    {
        Circle = 1,
        Slider = 1 << 1,
        NewCombo = 1 << 2,
        Spinner = 1 << 3,
        ComboSkip1 = 1 << 4,
        ComboSkip2 = 1 << 5,
        ComboSkip3 = 1 << 6,
        Hold = 1 << 7,
    }

    [Flags]
    public enum HitObjectSound
    {
        Normal = 1,
        Whistle = 1 << 1,
        Finish = 1 << 2,
        Clap = 1 << 3,
    }

    readonly public int x;
    readonly public int y;
    readonly public int time;
    readonly public HitObjectType type;
    readonly public HitObjectSound hitSound;

    readonly public SliderObjectParams? sliderParams;
    readonly public SpinnerObjectParams? spinnerParams;

    public HitObject(string line)
    {
        string[] parts = line.Split(',');

        x = int.Parse(parts[0]);
        y = int.Parse(parts[1]);
        time = int.Parse(parts[2]);
        type = (HitObjectType)int.Parse(parts[3]);
        hitSound = (HitObjectSound)int.Parse(parts[4]);

        string remaining = StringUtilities.JoinAfter(parts, startIndex: 5, separator: ',');
        if (type.HasFlag(HitObjectType.Circle))
        {
            sliderParams = null;
            spinnerParams = null;
        }
        else if (type.HasFlag(HitObjectType.Slider))
        {
            sliderParams = new(remaining);
            spinnerParams = null;
        }
        else if (type.HasFlag(HitObjectType.Spinner))
        {
            spinnerParams = new(remaining);
            sliderParams = null;
        }
        else
        {
            sliderParams = null;
            spinnerParams = null;
        }
    }

    private List<HitObjectSound> ParseHitSample(string hitSampleString)
    {
        List<HitObjectSound> hitSample = [];

        string[] parts = hitSampleString.Split(':');

        foreach (string part in parts)
        {
            if (string.IsNullOrWhiteSpace(part)) continue;

            hitSample.Add((HitObjectSound)int.Parse(part));
        }

        return hitSample;
    }
}