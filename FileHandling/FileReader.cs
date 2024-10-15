namespace FileHandling;

public static class FileReader
{
    public static string[] ReadAllFromPath(string path)
    {
        var result = new List<string>();

        using (StreamReader reader = new StreamReader(path))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                result.Add(line);
            }
        }

        return result.ToArray();
    }
}