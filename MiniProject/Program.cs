using MiniProject.utils;

namespace MiniProject;

public static class Program
{
    private const string EndPath = "./F2.txt";
    
    public static void Main(string[] args)
    {
        if (args.Length <= 0)
        {
            Console.WriteLine("MiniProject has no command line arguments");
            return;
        }
        
        var path = args[0];
        
        if (!File.Exists(path))
        {
            Console.WriteLine($"File {path} does not exists");
            return;
        }
        
        List<string>? fullFile = Functions.ReadFromFileToList(path);

        if (fullFile == null || fullFile.Count <= 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        SortedSet<string> split;
        if (args.Contains("-a"))
        {
            split = Functions.RemoveDuplicates(fullFile, true);
        }
        else if (args.Contains("-d"))
        {
            split = Functions.RemoveDuplicates(fullFile, false);
        }
        else
        {
            Console.WriteLine("Missing command line arguments. (path|-a|-d)");
            return;
        }

        var mergeWords = string.Empty;
        for (var i = 0; i < split.Count; i++)
        {
            if (i % 10 == 0)
            {
                mergeWords += Environment.NewLine;
            }
            mergeWords += split.ElementAt(i) + ", ";
        }

        var frequentWord = Functions.MostFrequentWord(fullFile);
        
        var mergedFrequentWord = $"The most frequent word in the text is '{frequentWord.Item1}', count: {frequentWord.Item2}";
        
        var fullContent = $"{mergeWords}{Environment.NewLine}{mergedFrequentWord}{Environment.NewLine}**********";
        
        var isSaved = Functions.WriteToTxtFile(EndPath, fullContent);

        Console.WriteLine(isSaved ? $"The file F2 has been created." : $"The file F2 has not been created.");
    }

    
}