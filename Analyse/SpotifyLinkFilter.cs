namespace Analyse;
public class SpotifyLinkFilter : FilterAnalyser
{
    public SpotifyLinkFilter(string sendingPersonName, string receivingPersonName)
        : base(sendingPersonName, receivingPersonName, new string[]
        {
            // todo: make filters more specific
            "spotify",
        })
    { }
}