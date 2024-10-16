using DataTypes;

namespace Analyse;

public interface IAnalyser
{
    public string GenerateReport(IEnumerable<ChatItem> conversation);
}