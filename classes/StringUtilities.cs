


using System.Text;

public static class StringUtilities
{
    public static string JoinAfter(string[] stringArray, int startIndex, char? separator = null)
    {
        if (stringArray == null || startIndex >= stringArray.Length) return string.Empty;

        StringBuilder sb = new();

        for (int i = startIndex; i < stringArray.Length; i++)
        {
            sb.Append(stringArray[i]);

            if (separator != null && i < stringArray.Length - 1)
            {
                sb.Append(separator);
            }
        }
        return sb.ToString();
    }
}