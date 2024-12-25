


public class EdgeSet
{
    readonly public int normalSet;
    readonly public int additionSet;

    public EdgeSet(string edgeSet)
    {
        string[] splitEdgeSet = edgeSet.Split(':');

        normalSet = int.Parse(splitEdgeSet[0]);
        additionSet = int.Parse(splitEdgeSet[1]);
    }
}