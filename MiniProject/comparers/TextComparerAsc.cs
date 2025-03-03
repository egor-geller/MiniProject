namespace MiniProject.comparers;

public class TextComparerAsc : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        return string.Compare(x, y, StringComparison.Ordinal);
    }
}