



public class DifficultySection
{
    readonly public double hPDrainRate;
    readonly public double circleSize;
    readonly public double overallDifficulty;
    readonly public double approachRate;
    readonly public double sliderMultiplier;
    readonly public double sliderTickRate;

    public DifficultySection(string[] lines)
    {
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) break;

            string[] keyValue = line.Split(':');
            string key = keyValue[0].Trim();
            string value = keyValue[1].Trim();

            switch (key)
            {
                case "HPDrainRate":
                    hPDrainRate = double.Parse(value);
                    break;
                case "CircleSize":
                    circleSize = double.Parse(value);
                    break;
                case "OverallDifficulty":
                    overallDifficulty = double.Parse(value);
                    break;
                case "ApproachRate":
                    approachRate = double.Parse(value);
                    break;
                case "SliderMultiplier":
                    sliderMultiplier = double.Parse(value);
                    break;
                case "SliderTickRate":
                    sliderTickRate = double.Parse(value);
                    break;
            }
        }
    }
}