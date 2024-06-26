namespace Pnsme.Domain.ValueObjects
{
    public class DateOfBirth
    {
        public DateTime Value { get; }

        public DateOfBirth(DateTime value)
        {
            if (value > DateTime.UtcNow)
                throw new ArgumentException("Date of birth cannot be in the future.");

            Value = value;
        }

        public int Age => (int)((DateTime.UtcNow - Value).TotalDays / 365.25);
    }
}