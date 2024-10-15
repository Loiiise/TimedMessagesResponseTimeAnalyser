namespace DataTypes;
public record class ChatItem
{
    public Person Person { get; init; }
    public DateTime TimeStamp { get; init; }
}