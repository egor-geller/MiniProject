using MiniProject.comparers;

namespace MiniProject.utils;

public static class Functions
{
    public static SortedSet<string> RemoveDuplicates(List<string> content, bool isAsc)
    {
        return isAsc
            ? new SortedSet<string>(content, new TextComparerAsc())
            : new SortedSet<string>(content, new TextComparerDesc());
    }

    public static Tuple<string, int> MostFrequentWord(List<string> content)
    {
        Dictionary<string, int> frequentWords = new();
        foreach (var word in content)
        {
            if (frequentWords.TryAdd(word, 1)) continue;
            var temp = frequentWords[word];
            frequentWords[word] = temp + 1;
        }

        var maxCount = 0;
        var mostFrequentWord = string.Empty;
        foreach (var word in frequentWords)
        {
            if (word.Value <= maxCount) continue;
            maxCount = word.Value;
            mostFrequentWord = word.Key;
        }

        return new Tuple<string, int>(mostFrequentWord, maxCount);
    }

    public static List<string>? ReadFromFileToList(string path)
    {
        var content = new List<string>();
        try
        {
            using var fileStream = new FileStream(path, FileMode.Open);
            using var streamReader = new StreamReader(fileStream);
            while (!streamReader.EndOfStream)
            {
                var str = streamReader.ReadLine();
                if (str == null || str.Trim().Length <= 0) continue;
                var temp = str.ToLower().Trim().Split(" ");
                content.AddRange(temp);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"EXCEPTION: {e}");
            return null;
        }

        return content;
    }

    public static bool WriteToTxtFile(string path, string content)
    {
        try
        {
            FileStream fileStream = new(path, FileMode.Create);
            using var streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(content);
        }
        catch (Exception e)
        {
            Console.WriteLine($"EXCEPTION: {e}");
            return false;
        }

        return true;
    }
}