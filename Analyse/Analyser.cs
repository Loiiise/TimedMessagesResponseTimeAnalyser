using DataTypes;

namespace Analyse;
public abstract class Analyser : IAnalyser
{
    public Analyser(string sendingPersonName, string receivingPersonName)
    {
        _sendingPersonName = sendingPersonName;
        _receivingPersonName = receivingPersonName;
    }

    internal string _sendingPersonName { get; init; }
    internal string _receivingPersonName { get; init; }

    public abstract string GenerateReport(IEnumerable<ChatItem> conversation);
}