using DataTypes.ChatProfiling;
using FileHandling;

namespace TimedMessagesResponseTimeAnalyser;

internal class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Any() ? args[0] : string.Empty;

        if (inputPath == string.Empty)
        {
            Console.WriteLine("What is the path of the file you want to analyse?");
            inputPath = Console.ReadLine()!;
        }

        var rawMessages = FileReader.ReadAllFromPath(inputPath);
        var profiler = new WhatsAppProfiler();

        var chatItems = profiler.GenerateFromPlainLines(rawMessages);

        // todo: chat processing 

        // todo: output
    }
}
