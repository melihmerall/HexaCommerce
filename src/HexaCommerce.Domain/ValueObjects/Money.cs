using System;
using System.Globalization;

namespace HexaCommerce.Domain.ValueObjects
{
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency = "USD")
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative", nameof(amount));

            Amount = amount;
            Currency = currency?.ToUpperInvariant() ?? "USD";
        }

        public static Money Zero(string currency = "USD") => new Money(0, currency);

        public static Money operator +(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot add money with different currencies");

            return new Money(left.Amount + right.Amount, left.Currency);
        }

        public static Money operator -(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot subtract money with different currencies");

            return new Money(left.Amount - right.Amount, left.Currency);
        }

        public static Money operator *(Money money, decimal multiplier)
        {
            return new Money(money.Amount * multiplier, money.Currency);
        }

        public static Money operator /(Money money, decimal divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException();

            return new Money(money.Amount / divisor, money.Currency);
        }

        public static bool operator ==(Money left, Money right)
        {
            return left?.Equals(right) ?? right is null;
        }

        public static bool operator !=(Money left, Money right)
        {
            return !(left == right);
        }

        public static bool operator <(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot compare money with different currencies");

            return left.Amount < right.Amount;
        }

        public static bool operator >(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot compare money with different currencies");

            return left.Amount > right.Amount;
        }

        public bool Equals(Money other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return Amount == other.Amount && Currency == other.Currency;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public override string ToString()
        {
            return $"{Amount:C} {Currency}";
        }

        public string ToString(string format)
        {
            return Amount.ToString(format, CultureInfo.InvariantCulture) + " " + Currency;
        }
    }
} 