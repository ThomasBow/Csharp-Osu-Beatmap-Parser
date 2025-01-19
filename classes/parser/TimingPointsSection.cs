


public class TimingPointsSection
{
    public readonly List<TimingPoint> TimingPoints;

    public TimingPointsSection(string[] lines)
    {
        TimingPoints = [];

        foreach (string line in lines)
        {
            Debugger.currentLine = line;

            if (string.IsNullOrWhiteSpace(line)) break;

            TimingPoint timingPoint = new(line);
            TimingPoints.Add(timingPoint);
        }
    }
}