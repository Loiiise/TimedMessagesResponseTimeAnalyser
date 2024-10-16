namespace FileHandling;
public class FileWriter
{
    public static void WriteAllToPath(string path, string text)
    {
        File.WriteAllText(path, text);
    }
}