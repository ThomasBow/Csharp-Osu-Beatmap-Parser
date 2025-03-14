




public class MapAndSong : ITrainingData
{

    public Map Map { get; private set; }
    public SongData Song { get; private set; }

    public MapAndSong(Map map, SongData song)
    {
        Map = map;
        Song = song;
    }

    public (int[] features, int[] labels) GetFeaturesAndLabels()
    {
        (int[] mapFeatures, int[] mapLabels) = Map.GetFeaturesAndLabels();
        (int[] songFeatures, int[] songLabels) = Song.GetFeaturesAndLabels();

        int[] features = [.. mapFeatures, .. songFeatures];
        int[] labels = [.. mapLabels, .. songLabels];

        return (features, labels);
    }
}