using dhanman.money.Domain.Entities;
using dhanman.money.Domain.Entities.Users;
using Dhanman.Sales.Domain.Entities;

namespace dhanman.money.Domain.Utility;

public static class Ensure
{
    public static void NotZero(decimal value, string message, string argumentName)
    {
        if (value == decimal.Zero)
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotGreaterThanZero(decimal value, string message, string argumentName)
    {
        if (value > decimal.Zero)
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotLessThanZero(decimal value, string message, string argumentName)
    {
        if (value < decimal.Zero)
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotEmpty(string value, string message, string argumentName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotEmpty(Guid value, string message, string argumentName)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotEmpty(DateTime value, string message, string argumentName)
    {
        if (value == default)
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotEmpty(Currency value, string message, string argumentName)
    {
        if (value == Currency.None)
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotEmpty(Money value, string message, string argumentName)
    {
        if (value == Money.None)
        {
            throw new ArgumentException(message, argumentName);
        }
    }
}
