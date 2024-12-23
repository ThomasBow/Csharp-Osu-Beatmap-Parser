


public class TimingPointsSection
{
    public readonly List<TimingPoint> TimingPoints;

    public TimingPointsSection(string[] lines)
    {
        TimingPoints = [];

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) break;

            TimingPoint timingPoint = new(line);
            TimingPoints.Add(timingPoint);
        }
    }
}