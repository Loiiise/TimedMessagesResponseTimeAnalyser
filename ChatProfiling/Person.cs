namespace DataTypes;
public enum Person : byte
{
    SendingPerson,
    ReceivingPerson,
}

public static class PersonExtensions
{
    public static Person ParsePerson(string input, string sender, string receiver) =>
        input == sender ? Person.SendingPerson :
        input == receiver ? Person.ReceivingPerson :
        throw new ArgumentException($"{input} is not a valid person. Expected either {sender} or {receiver}");
}