using System.Globalization;

namespace DataTypes.ChatProfiling;
public class WhatsAppProfiler : IChatProfiler
{
    public WhatsAppProfiler(string nameSender, string nameReceiver)
    {
        _nameSender = nameSender;
        _nameReceiver = nameReceiver;
    }

    public IEnumerable<ChatItem> GenerateFromPlainLines(string[] lines) => lines.Select(GenerateFromPlainLine).Where(l => l != null).Select(l => l!);
    public ChatItem? GenerateFromPlainLine(string line)
    {
        // This is so ugly, why is WhatsApp's format like this?
        var dateTimeAndOtherData = line.Split(" - ");
        if (dateTimeAndOtherData.Length < 2)
        {
            return null;
        }

        var personAndMessage = dateTimeAndOtherData[1].Split(": ");

        var dateTimeString = dateTimeAndOtherData[0];
        var personString = personAndMessage[0];


        if (PersonExtensions.TryParsePerson(personString, _nameSender, _nameReceiver, out var person) &&
            DateTime.TryParse(dateTimeString, DateTimeFormatInfo.InvariantInfo, out var timeStamp))
        {
            return new ChatItem
            {
                Person = person,
                TimeStamp = timeStamp,
            };
        }

        return null;
    }

    private readonly string _nameSender;
    private readonly string _nameReceiver;
}