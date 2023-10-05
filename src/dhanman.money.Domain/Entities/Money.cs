using B2aTech.CrossCuttingConcern.Core.Primitives;
using dhanman.money.Domain.Utility;
using Dhanman.Sales.Domain.Entities;

namespace dhanman.money.Domain.Entities;

public sealed class Money : ValueObject
{
    public static readonly Money None = new Money();

    public Money(decimal amount, Currency currency)
    {
        Ensure.NotEmpty(currency, "The currency is required.", nameof(currency));

        Amount = amount;
        Currency = currency;
    }
    private Money()
    {
        Currency = Currency.None;
    }

    public decimal Amount { get; }

    public Currency Currency { get; }

    public static Money operator +(Money left, Money right)
    {
        AssertCurrenciesAreEqual(left, right);

        return new Money(left.Amount + right.Amount, left.Currency);
    }

    public static Money operator -(Money left, Money right)
    {
        AssertCurrenciesAreEqual(left, right);

        return new Money(left.Amount - right.Amount, left.Currency);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Amount;
        yield return Currency;
    }

    private static void AssertCurrenciesAreEqual(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new InvalidOperationException(
                $"The currencies {left.Currency.Name} and {right.Currency.Name} are not the same currency.");
        }
    }
}
