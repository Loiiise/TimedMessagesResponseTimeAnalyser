namespace DataTypes.ChatProfiling;

public interface IChatProfiler
{
    public IEnumerable<ChatItem> GenerateFromPlainLines(string[] lines);
}
