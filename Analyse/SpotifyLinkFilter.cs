using DataTypes;

namespace Analyse;
public class SpotifyLinkFilter : Analyser
{
    public SpotifyLinkFilter(string sendingPersonName, string receivingPersonName) : base(sendingPersonName, receivingPersonName) { }

    public override string GenerateReport(IEnumerable<ChatItem> conversation)
    {
        throw new NotImplementedException();
    }
}