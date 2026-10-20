using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0040 : ProblemBase
{
    public override string Title => "Champernowne's Constant";

    public override string Solve()
    {
        var answer = GetNthDigit(1) * GetNthDigit(10) * GetNthDigit(100) * GetNthDigit(1000) * GetNthDigit(10000) * GetNthDigit(100000) * GetNthDigit(1000000);

        return answer.ToString();
    }

    public static int GetNthDigit(long n)
    {
        long digitLength = 1;     // numbers with 1 digit, then 2 digits, etc.
        long count = 9;           // how many numbers have 'digitLength' digits
        long start = 1;           // first number with 'digitLength' digits

        // Step 1: Find which digit-length block contains the n-th digit
        while (n > digitLength * count)
        {
            n -= digitLength * count;
            digitLength++;
            count *= 10;
            start *= 10;
        }

        // Step 2: Find the exact number containing the digit
        var number = start + (n - 1) / digitLength;

        // Step 3: Extract the digit inside that number
        var digitIndex = (int)((n - 1) % digitLength);
        return number.ToString()[digitIndex] - '0';
    }

}





