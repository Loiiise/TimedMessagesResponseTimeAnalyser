using DataTypes.ChatProfiling;
using FileHandling;

namespace TimedMessagesResponseTimeAnalyser;

internal class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Any() ? args[0] : GetStringFromUser("What is the path of the file you want to analyse?");

        var sender = GetStringFromUser("What is the name of the sender? (as used in the chat file)");
        var receiver = GetStringFromUser("What is the name of the receiver? (as used in the chat file)");

        var rawMessages = FileReader.ReadAllFromPath(inputPath);
        var profiler = new WhatsAppProfiler(sender, receiver);

        var chatItems = profiler.GenerateFromPlainLines(rawMessages);

        // todo: chat processing 

        // todo: output
    }

    private static string GetStringFromUser(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine()!;
    }
}
