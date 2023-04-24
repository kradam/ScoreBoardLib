namespace ScoreBoardTable
{
    using ScoreBoardLib;
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultMatchSortingStrategy : IMatchSortingStrategy
    {
        public IList<IMatch> Sort(IList<IMatch> matches)
        {
            return matches.OrderByDescending(m => m.Score.Home + m.Score.Away)
                          .ThenByDescending(m => m.StartTime)
                          .ToList();
        }
    }
}
