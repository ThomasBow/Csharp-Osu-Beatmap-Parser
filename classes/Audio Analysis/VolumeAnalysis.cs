


public class VolumeAnalysis
{
    public static float CalculateRMS(float[] samples)
    {
        double sum = 0;
        foreach (float sample in samples)
        {
            sum += sample * sample;
        }
        return (float)Math.Sqrt(sum / samples.Length);
    }

    public static float CalculatePeakAmplitude(float[] samples)
    {
        return samples.Max();
    }
}