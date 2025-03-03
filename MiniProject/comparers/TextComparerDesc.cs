namespace MiniProject.comparers;

public class TextComparerDesc : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        return string.Compare(y, x, StringComparison.Ordinal);
    }
}