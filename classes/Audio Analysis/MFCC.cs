


using MathNet.Numerics;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;

public class MFCC
{
    public static float[] ComputeMFCC(float[] frame, int sampleRate, int numFilters = 26, int numCoefficients = 13)
    {
        int frameSize = frame.Length;
        var fftResult = new Complex[frameSize];
        Array.Copy(frame.Select(s => new Complex(s, 0)).ToArray(), fftResult, frameSize);

        // Compute FFT
        Fourier.Forward(fftResult, FourierOptions.NoScaling);

        // Compute power spectrum
        float[] powerSpectrum = new float[frameSize / 2];
        for (int i = 0; i < frameSize / 2; i++)
        {
            powerSpectrum[i] = (float)fftResult[i].MagnitudeSquared();
        }

        // Apply Mel filter bank
        float[][] melFilters = CreateMelFilterBank(frameSize / 2, sampleRate, numFilters);
        float[] filterEnergies = new float[numFilters];
        for (int i = 0; i < numFilters; i++)
        {
            filterEnergies[i] = melFilters[i].Zip(powerSpectrum, (m, p) => m * p).Sum();
        }

        // Take the logarithm
        float[] logFilterEnergies = filterEnergies.Select(e => (float)Math.Log(e + 1e-10)).ToArray();

        // Compute DCT to get MFCCs
        float[] mfccs = new float[numCoefficients];
        for (int i = 0; i < numCoefficients; i++)
        {
            mfccs[i] = (float)logFilterEnergies.Select((e, j) => e * Math.Cos(Math.PI * i * (j + 0.5) / numFilters)).Sum();
        }

        return mfccs;
    }

    private static float[][] CreateMelFilterBank(int fftSize, int sampleRate, int numFilters)
    {
        float minMel = 0;
        float maxMel = 2595 * (float)Math.Log10(1 + (sampleRate / 2) / 700.0);

        float[] melPoints = Enumerable.Range(0, numFilters + 2)
            .Select(i => minMel + i * (maxMel - minMel) / (numFilters + 1))
            .ToArray();

        float[] freqPoints = melPoints.Select(m => 700 * (Math.Pow(10, m / 2595) - 1)).Select(f => (float)f).ToArray();
        float[] binPoints = freqPoints.Select(f => fftSize * f / (sampleRate / 2)).ToArray();

        float[][] filters = new float[numFilters][];
        for (int i = 0; i < numFilters; i++)
        {
            filters[i] = new float[fftSize];
            for (int j = 0; j < fftSize; j++)
            {
                if (j < binPoints[i]) filters[i][j] = 0;
                else if (j <= binPoints[i + 1]) filters[i][j] = (j - binPoints[i]) / (binPoints[i + 1] - binPoints[i]);
                else if (j <= binPoints[i + 2]) filters[i][j] = (binPoints[i + 2] - j) / (binPoints[i + 2] - binPoints[i + 1]);
                else filters[i][j] = 0;
            }
        }

        return filters;
    }
}