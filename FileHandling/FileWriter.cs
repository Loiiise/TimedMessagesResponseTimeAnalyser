namespace FileHandling;
public class FileWriter
{
    public static void WriteAllToPath(string path, string[] lines)
    {
        File.WriteAllLines(path, lines);
    }
}