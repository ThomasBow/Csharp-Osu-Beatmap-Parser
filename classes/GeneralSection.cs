


public class GeneralSection
{
    const string AudioFilename = "audio.mp3";
    readonly int AudioLeadIn;
    readonly int PreviewTime;
    const int Countdown = 0;
    readonly string SampleSet;
    readonly double StackLeniency;
    const int Mode = 0;
    const bool LetterboxInBreaks = false;

    public GeneralSection(string[] lines)
    {
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) break;

            string[] parts = line.Split(':');

            string key = parts[0];
            string value = parts[1];


        }
    }

    private void ParseGeneralSectionLine(string key, string value)
    {
        switch (key)
        {
            case "AudioFilename":
                // Do nothing
                break;
            case "AudioLeadIn":
                break;
            case "PreviewTime":
                break;
            case "Countdown":
                // Do nothing
                break;
            case "SampleSet":
                break;
            case "StackLeniency":
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