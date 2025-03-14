


using Tensorflow;

public interface ITrainingData
{
    public (int[] features, int[] labels) GetFeaturesAndLabels();
}