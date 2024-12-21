


using System.Numerics;
using System.Linq;

public class SliderObjectParams
{
    public enum CurveType
    {
        Linear,
        Perfect,
        Bezier,
        Catmull
    }

    readonly public CurveType curveType;
    readonly public List<Vector2> controlPoints;
    readonly public int slides;
    readonly public double length;
    readonly public List<int> edgeSounds;
    readonly public List<EdgeSet> edgeSets;

    readonly public string rest;

    // Slider syntax: 
    // x,y,time,type,hitSound,curveType|curvePoints,slides,length,edgeSounds,edgeSets,hitSample
    public SliderObjectParams(string @params)
    {
        string[] splitParams = @params.Split(',');
        string curveParams = splitParams[0];
        string slidesParams = splitParams[1];
        string lengthParams = splitParams[2];
        string edgeSoundsParams = splitParams[3];
        string edgeSetsParams = splitParams[4];

        (curveType, controlPoints) = ParseCurveParams(curveParams);

        slides = ParseSlides(slidesParams);

        length = ParseLength(lengthParams);

        edgeSounds = ParseEdgeSounds(edgeSoundsParams);

        edgeSets = ParseEdgeSets(edgeSetsParams);

        rest = StringUtilities.JoinAfter(splitParams, startIndex: 5, separator: ',');
    }

    private (CurveType, List<Vector2>) ParseCurveParams(string curveParams)
    {
        string[] curveParamsSplit = curveParams.Split('|');
        string curveTypeString = curveParamsSplit[0];
        string curvePoints = StringUtilities.JoinAfter(curveParamsSplit, startIndex: 1, separator: '|');

        CurveType curveType = ParseCurveType(curveTypeString);
        List<Vector2> controlPoints = ParseCurvePoints(curvePoints);
        return (curveType, controlPoints);
    }

    private CurveType ParseCurveType(string curveTypeString)
    {
        CurveType curveType = (CurveType)int.Parse(curveTypeString);
        return curveType;
    }

    private List<Vector2> ParseCurvePoints(string curvePoints)
    {
        string[] curvePointsSplit = curvePoints.Split('|');
        List<Vector2> controlPoints = curvePointsSplit
            .Select(ParseControlPoint)
            .ToList();
        return controlPoints;
    }

    private Vector2 ParseControlPoint(string controlPointString)
    {
        string[] splitPoint = controlPointString.Split(':');
        float x = float.Parse(splitPoint[0]);
        float y = float.Parse(splitPoint[1]);
        Vector2 controlPoint = new(x, y);
        return controlPoint;
    }

    private int ParseSlides(string slidesParams)
    {
        int slides = int.Parse(slidesParams);
        return slides;
    }

    private double ParseLength(string lengthParams)
    {
        double length = double.Parse(lengthParams);
        return length;
    }

    private List<int> ParseEdgeSounds(string edgeSoundsParams)
    {
        string[] edgeSoundsSplit = edgeSoundsParams.Split('|');
        List<int> edgeSounds = edgeSoundsSplit
            .Select(int.Parse)
            .ToList();
        return edgeSounds;
    }

    public List<EdgeSet> ParseEdgeSets(string edgeSetsParams)
    {
        List<string> edgeSetsString = edgeSetsParams
            .Split('|')
            .ToList();

        List<EdgeSet> edgeSets = edgeSetsString
            .Select(ParseEdgeSet)
            .ToList();

        return edgeSets;
    }

    private EdgeSet ParseEdgeSet(string edgeSetString)
    {
        EdgeSet edgeSet = new(edgeSetString);
        return edgeSet;
    }
}