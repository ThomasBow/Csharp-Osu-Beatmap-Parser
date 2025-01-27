

using System;
using Tensorflow;
using Tensorflow.Keras;
using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Keras.Engine;
using Tensorflow.Keras.Layers;
using Tensorflow.Keras.Losses;
using Tensorflow.Keras.Models;
using Tensorflow.Keras.Optimizers;
using Tensorflow.NumPy;

public class RNN<Data> where Data : ITrainingData
{


    public RNN(int steps, int featuresPerStep, IEnumerable<Data> maps)
    {
        var inputShape = (steps, featuresPerStep);

        Sequential model = new(new());

        model.add(new GRU(new()
        {
            Units = 128,
            InputShape = inputShape,
            ReturnSequences = false
        }));

        model.add(new Dense(new()
        {
            Units = 1,
        }));

        Adam adam = new();
        BinaryCrossentropy binaryCrossentropy = new();
        string[] metrics = ["Accuracy"];

        model.compile(
            optimizer: adam,
            loss: binaryCrossentropy,
            metrics: metrics
        );

        model.summary();

        int samples = 100;
        NDArray xTrain = np.random.randn(samples, steps, featuresPerStep);
        NDArray yTrain = np.random.randint(low: 2, size: samples);

        model.fit(xTrain, yTrain, batch_size: 32, epochs: 10);

        Console.WriteLine("Training complete");
    }
}