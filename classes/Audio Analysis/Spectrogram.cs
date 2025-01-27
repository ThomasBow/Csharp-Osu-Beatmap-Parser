


using NAudio.Dsp;

public class Spectrogram
{

    // I'm gonna be honest, I have no idea what this does, but gpt spat out this
    public static float[][] ComputeSpectrogram(float[] audio, int sampleRate, int frameSize = 1024, int hopSize = 512)
    {
        int numFrames = (audio.Length - frameSize) / hopSize + 1;
        float[][] spectrogram = new float[numFrames][];

        // Apply FFT to each frame
        for (int i = 0; i < numFrames; i++)
        {
            float[] frame = new float[frameSize];
            Array.Copy(audio, i * hopSize, frame, 0, frameSize);

            // Apply a Hamming window
            for (int j = 0; j < frameSize; j++)
            {
                frame[j] *= (float)(0.54 - 0.46 * Math.Cos(2 * Math.PI * j / (frameSize - 1)));
            }

            // Compute FFT
            Complex[] fftResult = new Complex[frameSize];
            FastFourierTransform.FFT(true, (int)Math.Log(frameSize, 2), fftResult);

            // Compute magnitude spectrum
            spectrogram[i] = new float[frameSize / 2];
            for (int j = 0; j < frameSize / 2; j++)
            {
                spectrogram[i][j] = (float)Math.Sqrt(fftResult[j].X * fftResult[j].X + fftResult[j].Y * fftResult[j].Y);
            }
        }

        return spectrogram;
    }
}