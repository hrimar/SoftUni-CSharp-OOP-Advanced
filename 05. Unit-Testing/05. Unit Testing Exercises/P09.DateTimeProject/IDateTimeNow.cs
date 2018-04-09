using System;
using System.Collections.Generic;
using System.Text;

namespace P09.DateTimeProject
{
    public interface IDateTimeNow : IComparable<DateTime>, IConvertible, IEquatable<DateTime>, IFormattable
    {
        DateTime Now { get; }
        int Day { get; }

        DateTime AddDays(double value);

        DateTime AddHours(double value);
    }
}
