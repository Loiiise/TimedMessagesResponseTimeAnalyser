using System.Globalization;

namespace DataTypes.ChatProfiling;
public class WhatsAppProfiler : IChatProfiler
{
    public WhatsAppProfiler(string nameSender, string nameReceiver)
    {
        _nameSender = nameSender;
        _nameReceiver = nameReceiver;
    }

    public IEnumerable<ChatItem> GenerateFromPlainLines(string[] lines) => lines.Select(GenerateFromPlainLine);
    public ChatItem GenerateFromPlainLine(string line)
    {
        // This is so ugly, why is WhatsApp's format like this?
        var dateTimeAndOtherData = line.Split(" - ");
        var personAndMessage = dateTimeAndOtherData[1].Split(":");

        var dateTimeString = dateTimeAndOtherData[0];
        var personString = personAndMessage[0];

        return new ChatItem
        {
            Person = PersonExtensions.ParsePerson(personString, _nameSender, _nameReceiver),
            TimeStamp = DateTime.Parse(dateTimeString, DateTimeFormatInfo.InvariantInfo),
        };
    }

    private readonly string _nameSender;
    private readonly string _nameReceiver;
}