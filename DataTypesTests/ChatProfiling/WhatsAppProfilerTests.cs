using DataTypes;
using DataTypes.ChatProfiling;
using Shouldly;

namespace DataTypesTests.ChatProfiling;

public class WhatsAppProfilerTests
{
    [Theory, MemberData(nameof(GenerateWhatsAppMessageData))]
    public void CanParseMessages(DateTime dateTime, Person person, string personName, string message)
    {
        var profiler = GetDefaultProfiler();
        var whatsAppMessage = ToWhatsAppFormat(dateTime, personName, message);

        var chatItem = profiler.GenerateFromPlainLine(whatsAppMessage);

        chatItem.Person.ShouldBe(person);
        chatItem.TimeStamp.ShouldBe(dateTime);
    }

    public static IEnumerable<object[]> GenerateWhatsAppMessageData()
    {
        yield return new object[] { new DateTime(2021, 4, 24, 10, 53, 00), Person.SendingPerson, nameof(Person.SendingPerson), "blabla" };
        yield return new object[] { new DateTime(2021, 4, 24, 10, 54, 00), Person.ReceivingPerson, nameof(Person.ReceivingPerson), "blabla2" };
    }

    private WhatsAppProfiler GetDefaultProfiler() => new WhatsAppProfiler(nameof(Person.SendingPerson), nameof(Person.ReceivingPerson));
    private string ToWhatsAppFormat(DateTime dateTime, string personName, string message) =>
        $"{dateTime.ToString("MM/dd/yy, hh:mm")} - {personName}: {message}";
}