


public class SpinnerObjectParams
{
    readonly public int endTime;
    readonly public string rest;

    public SpinnerObjectParams(string @params)
    {
        string[] splitParams = @params.Split(',');

        endTime = int.Parse(splitParams[0]);
        rest = StringUtilities.JoinAfter(splitParams, startIndex: 1, separator: ',');
    }
}