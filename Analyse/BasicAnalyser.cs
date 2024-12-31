using DataTypes;

namespace Analyse;

/// <summary>
/// This analyser is very naive. It doesn't consider any breaks but assumes a constant flow of conversation.
/// </summary>
public class BasicAnalyser : Analyser
{
    public BasicAnalyser(string sendingPersonName, string receivingPersonName) : base(sendingPersonName, receivingPersonName) { }

    public override string GenerateReport(IEnumerable<ChatItem> conversation)
    {
        var firstItem = conversation.First();
        var currentPerson = firstItem.Person;
        var currentTime = firstItem.TimeStamp;

        var sendingPersonTotalResponseTime = TimeSpan.Zero;
        var sendingPersonOccurrences = 0;
        var receivingPersonTotalResponseTime = TimeSpan.Zero;
        var receivingPersonOccurrences = 0;

        foreach (var item in conversation.Skip(1))
        {
            if (item.Person == currentPerson) continue;

            var timeToRespond = item.TimeStamp.Subtract(currentTime);

            if (item.Person == Person.SendingPerson)
            {
                sendingPersonTotalResponseTime += timeToRespond;
                ++sendingPersonOccurrences;
            }
            else
            {
                receivingPersonTotalResponseTime += timeToRespond;
                ++receivingPersonOccurrences;
            }

            currentPerson = item.Person;
            currentTime = item.TimeStamp;
        }

        return $"""
            {_sendingPersonName}: {sendingPersonTotalResponseTime / sendingPersonOccurrences}
            {_receivingPersonName}: {receivingPersonTotalResponseTime / receivingPersonOccurrences}
            """;
    }
}