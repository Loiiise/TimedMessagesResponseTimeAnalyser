using Analyse;
using DataTypes.ChatProfiling;
using FileHandling;

namespace TimedMessagesResponseTimeAnalyser;

internal class Program
{
    static void Main(string[] args)
    {
        var amountOfArgs = args.Length;

        var inputPath = args.Length > 0 ? args[0] : GetStringFromUser("What is the path of the file you want to analyse?");

        var sender = args.Length > 1 ? args[1] : GetStringFromUser("What is the name of the sender? (as used in the chat file)");
        var receiver = args.Length > 2 ? args[2] : GetStringFromUser("What is the name of the receiver? (as used in the chat file)");

        var rawMessages = FileReader.ReadAllFromPath(inputPath);
        var profiler = new WhatsAppProfiler(sender, receiver);

        var chatItems = profiler.GenerateFromPlainLines(rawMessages);

        var analyser = new SpotifyLinkFilter(sender, receiver);
        var report = analyser.GenerateReport(chatItems);

        var outputPath = Path.ChangeExtension(inputPath, _resultExtension + ".txt");
        FileWriter.WriteAllToPath(outputPath, report);
    }

    private static string GetStringFromUser(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine()!;
    }

    private const string _resultExtension = "TMRTA";
}
