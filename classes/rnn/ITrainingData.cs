


using Tensorflow.NumPy;

public interface ITrainingData
{
    public abstract NDArray X();
    public abstract NDArray Y();
}