using System.Diagnostics.CodeAnalysis;

namespace DataTypes;
public enum Person : byte
{
    None,
    SendingPerson,
    ReceivingPerson,
}

public static class PersonExtensions
{
    public static Person ParsePerson(string input, string sender, string receiver)
    {
        if (TryParsePerson(input, sender, receiver, out var result, out var exception))
        {
            return result;
        }

        throw exception;
    }

    public static bool TryParsePerson(string input, string sender, string receiver, [MaybeNullWhen(false)] out Person result)
        => TryParsePerson(input, sender, receiver, out result, out var _);

    private static bool TryParsePerson(string input, string sender, string receiver, [NotNullWhen(true)][MaybeNullWhen(false)] out Person result, [NotNullWhen(false)][MaybeNullWhen(true)] out Exception exception)
    {
        result =
            input == sender ? Person.SendingPerson :
            input == receiver ? Person.ReceivingPerson :
            default;

        exception = result == default ?
            new ArgumentException($"{input} is not a valid person. Expected either {sender} or {receiver}") :
            null;

        return result != default;
    }
}