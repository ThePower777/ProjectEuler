using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0019 : ProblemBase
{
    public override string Title => "Counting Sundays";

    public override string Solve()
    {
        var totalSundays = 0;
        for (var year = 1901; year <= 2000; year++)
        {
            for (var month = 1; month <= 12; month++)
            {
                var firstDayOfMonth = new DateTime(year, month, 1);
                if (firstDayOfMonth.DayOfWeek == DayOfWeek.Sunday)
                {
                    totalSundays++;
                }
            }
        }

        return totalSundays.ToString();
    }
}


