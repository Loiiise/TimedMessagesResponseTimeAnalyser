using DataTypes;

namespace Analyse;
public abstract class FilterAnalyser : Analyser
{
    public FilterAnalyser(string sendingPersonName, string receivingPersonName, string[] filterOnTags) : base(sendingPersonName, receivingPersonName)
    {
        _filterOnTags = filterOnTags;
    }

    public sealed override string GenerateReport(IEnumerable<ChatItem> conversation)
    {
        throw new NotImplementedException();
    }

    private readonly string[] _filterOnTags;
}