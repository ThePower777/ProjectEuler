using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0043 : ProblemBase
{
    public override string Title => "Sub-string Divisibility";

    public override string Solve()
    {
        var totalSum = 0L;
        var digits = new int[10];
        var usedDigits = new bool[10];
        var divisors = new[] { 0, 2, 3, 5, 7, 11, 13, 17 };

        for (var multiple = 0; multiple < 1000; multiple += 17)
        {
            digits[7] = multiple / 100;
            digits[8] = multiple / 10 % 10;
            digits[9] = multiple % 10;
            if (digits[7] == digits[8] || digits[7] == digits[9] || digits[8] == digits[9])
            {
                continue;
            }

            usedDigits[digits[7]] = true;
            usedDigits[digits[8]] = true;
            usedDigits[digits[9]] = true;
            BuildPandigitalNumbers(6);
            usedDigits[digits[7]] = false;
            usedDigits[digits[8]] = false;
            usedDigits[digits[9]] = false;
        }

        return totalSum.ToString();

        void BuildPandigitalNumbers(int position)
        {
            if (position == 0)
            {
                for (var digit = 1; digit <= 9; digit++)
                {
                    if (!usedDigits[digit])
                    {
                        var number = 0L;
                        digits[0] = digit;
                        foreach (var currentDigit in digits)
                        {
                            number = number * 10 + currentDigit;
                        }
                        totalSum += number;
                        break;
                    }
                }

                return;
            }

            for (var digit = 0; digit <= 9; digit++)
            {
                if (usedDigits[digit])
                {
                    continue;
                }

                var substring = digit * 100 + digits[position + 1] * 10 + digits[position + 2];
                if (substring % divisors[position] != 0)
                {
                    continue;
                }

                digits[position] = digit;
                usedDigits[digit] = true;
                BuildPandigitalNumbers(position - 1);
                usedDigits[digit] = false;
            }
        }
    }
}





