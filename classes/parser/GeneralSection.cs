


public class GeneralSection
{
    const string AudioFilename = "audio.mp3";
    readonly int AudioLeadIn = 0;
    readonly int PreviewTime = -1;
    const int Countdown = 0;
    readonly string SampleSet = "Normal";
    readonly double StackLeniency = 0.7;
    const int Mode = 0;
    const bool LetterboxInBreaks = false;

    public GeneralSection(string[] lines)
    {
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) break;

            string[] parts = line.Split(':');

            string key = parts[0].Trim();
            string value = parts[1].Trim();

            switch (key)
            {
                case "AudioFilename":
                    // Do nothing
                    break;
                case "AudioLeadIn":
                    AudioLeadIn = int.Parse(value);
                    break;
                case "PreviewTime":
                    PreviewTime = int.Parse(value);
                    break;
                case "Countdown":
                    // Do nothing
                    break;
                case "SampleSet":
                    SampleSet = value;
                    break;
                case "StackLeniency":
                    StackLeniency = double.Parse(value);
                    break;
                case "Mode":
                    // Do nothing
                    break;
                case "LetterboxInBreaks":
                    // Do nothing
                    break;
            }
        }
    }
}