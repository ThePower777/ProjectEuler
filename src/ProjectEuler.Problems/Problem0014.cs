using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0014: ProblemBase
{
    public override string Title => "Longest Collatz Sequence";

    //This version run 6 second
    public static string Solve2()
    {

        BigInteger maxNum = 0;
        var collatzNumber = 0;
        for (var i = 1; i < 1000000; i++)
        {
            var length = DigitHelpers.GetCollatzLength(i);
            if (length > maxNum)
            {
                maxNum = length;
                collatzNumber = i;
            }
        }
        return collatzNumber.ToString();
    }

    public override string Solve()
    {

        long currentSequenceLength; 
        long maxSequenceLength = 0;
        long result = 0;
        for (long currentNumber = 1; currentNumber < 1000000; currentNumber++)
        {
            currentSequenceLength = DigitHelpers.GetCollatzSequenceLengthRecursive(currentNumber);
            if (currentSequenceLength > maxSequenceLength)
            {
                maxSequenceLength = currentSequenceLength;
                result = currentNumber;
            }
        }
        return result.ToString();
    }

    
}


