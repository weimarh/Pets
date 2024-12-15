using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public partial record class Year
{
    private const string Pattern = @"^20\d{2}$";
    private Year(string value)
    {
        Value = value;
    }

    public static Year? Create(string value)
    {
        if (!YearRegex().IsMatch(value) || 
            value.Length != 4 || string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return new Year(value);
    }

    public string Value { get; init; }

    [GeneratedRegex(Pattern)]
    private static partial Regex YearRegex();
}
