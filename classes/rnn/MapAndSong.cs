




using Tensorflow.NumPy;

public class MapAndSong : ITrainingData
{

    public Map Map { get; private set; }
    public SongData Song { get; private set; }

    public MapAndSong(Map map, SongData song)
    {
        Map = map;
        Song = song;
    }

    public NDArray X()
    {
        throw new NotImplementedException();
    }

    public NDArray Y()
    {
        throw new NotImplementedException();
    }
}