


using NAudio.Wave;

public class SongData : ITrainingData
{
    public SongData(string osuMapFolderPath)
    {
        string audioFilePath = osuMapFolderPath + "/audio.mp3";

        using Mp3FileReader reader = new(audioFilePath);

        int bytesToRead = (int)reader.Length;

        byte[] samplesBuffer = new byte[bytesToRead];
        reader.ReadExactly(samplesBuffer, 0, bytesToRead);

        float[] samples = new float[bytesToRead / 2];
        for (int i = 0; i < bytesToRead; i++)
        {
            samples[i] = BitConverter.ToInt16(samplesBuffer, i * 2) / 32768f;
        }
    }

    public (int[] features, int[] labels) GetFeaturesAndLabels()
    {
        throw new NotImplementedException();
    }
}