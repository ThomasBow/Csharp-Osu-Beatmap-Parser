


public class HitObjectsSection
{
    readonly public List<HitObject> hitObjects;

    public HitObjectsSection(string[] lines)
    {
        hitObjects = ParseHitObjects(lines);
    }

    private List<HitObject> ParseHitObjects(string[] lines)
    {
        List<HitObject> hitObjects = [];

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) break;

            HitObject hitObject = new(line);
            hitObjects.Add(hitObject);
        }

        return hitObjects;
    }
}