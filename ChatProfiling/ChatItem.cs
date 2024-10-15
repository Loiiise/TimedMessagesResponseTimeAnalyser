namespace DataTypes;
public record class ChatItem
{
    public Person Person { get; init; }
    DateTime TimeStamp { get; init; }
}