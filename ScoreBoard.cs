namespace ScoreBoardTable
{
    using ScoreBoardLib;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Scoreboard : IScoreboard
    {
        private readonly IList<IMatch> _matches = new List<IMatch>();
        private readonly IMatchSortingStrategy _sortingStrategy;

        public Scoreboard(IMatchSortingStrategy sortingStrategy)
        {
            _sortingStrategy = sortingStrategy; // ?? throw new ArgumentNullException(nameof(sortingStrategy));
        }

        public IMatch StartNewGame(string homeTeam, string awayTeam)
        {
            var match = new Match(homeTeam, awayTeam);
            _matches.Add(match);
            return match;
        }

        public void UpdateScore(IMatch match, int home, int away)
        {
            
        }

        public void FinishGame(IMatch match)
        {
          
        }

        public IList<IMatch> GetInProgressGames()
        {
            return _sortingStrategy.Sort(_matches);
        }
    }

}