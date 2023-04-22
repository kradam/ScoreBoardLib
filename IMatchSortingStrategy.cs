namespace ScoreBoardTable
{
    using ScoreBoardLib;
    using System.Collections.Generic;

    public interface IMatchSortingStrategy
    {
        IList<IMatch> Sort(IList<IMatch> matches);
    }
}
