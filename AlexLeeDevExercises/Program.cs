using System.Text;

Console.WriteLine("Hello, World!");

Console.WriteLine(Helpers.PrintInterleavedOutput("abcdef", "123"));

var word = "122155555";
Console.WriteLine($"is {word} a Palindrome? : {Helpers.IsPalindrome(word)}"); 

//Helpers.FindSearchTextInDirectoryFiles(@"path", "searchQuery", "outputFileName");



public static class Helpers
{
    public static string PrintInterleavedOutput(string? str1, string? str2)
    {

        var interleaved = new StringBuilder();

        var biggestString = Math.Max(str1?.Length ?? 0, str2?.Length ?? 0);

        for (int i = 0; i < biggestString; i++)
        {
            if (i < (str1?.Length ?? 0))
                interleaved.Append(str1[i]);
            if (i < (str2?.Length ?? 0))
                interleaved.Append(str2[i]);
        }

        return interleaved.ToString();
    }

    public static bool IsPalindrome(string str)
    {
        return string.Equals(str, new string(str.Reverse().ToArray()), StringComparison.OrdinalIgnoreCase);
    }


    public static void FindSearchTextInDirectoryFiles(string directoryPath, string searchText, string destinationFileName)
    {

        DirectoryInfo directory = new DirectoryInfo(directoryPath);

        var filesProcessed = 0;
        var linesWithSearchTextFound = 0;
        var occurancesOfSearchTextFound = 0;


        //search for the files in parallel 
        Parallel.ForEach(directory.GetFiles(), file =>
        {
            using (var stream = file.OpenRead())
            {
                var contents = new StreamReader(stream).ReadToEnd();
                //find the matching lines in the file contents
                var matchingLines = contents.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                    .Where(line => line.Contains(searchText, StringComparison.OrdinalIgnoreCase));
                //get the number of occurances of the search text in each line
                if (matchingLines.Any())
                {
                    var occurancesInFile = matchingLines.Sum(line => line.ToLower().Split(new[] { searchText.ToLower() }, StringSplitOptions.None).Length - 1);
                    Interlocked.Add(ref occurancesOfSearchTextFound, occurancesInFile);
                    Interlocked.Add(ref linesWithSearchTextFound, matchingLines.Count());
                    //write the matching lines to the destination file
                    lock (typeof(Helpers))
                    {
                        File.AppendAllLines($@"c:\temp\{destinationFileName}", matchingLines);
                    }
                }

            }
            Interlocked.Increment(ref filesProcessed);
        });

        //log number of files processed, lines found with the search text, and number of occurances of the search text to the console
        Console.WriteLine($"Files Processed: {filesProcessed}");
        Console.WriteLine($"Lines Found With Search Text: {linesWithSearchTextFound}");
        Console.WriteLine($"Occurances Of Search Text Found: {occurancesOfSearchTextFound}");

    }
}