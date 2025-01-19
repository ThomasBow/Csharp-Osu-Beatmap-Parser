


using Tensorflow.NumPy;

public interface ITrainingData
{
    public NDArray X { get; }
    public NDArray Y { get; }
}