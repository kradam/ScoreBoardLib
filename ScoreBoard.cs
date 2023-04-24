namespace ScoreBoardTable
{
    using ScoreBoardLib;
    using System;
    using System.Collections.Generic;

    public class Scoreboard : IScoreboard
    {
        private readonly IList<IMatch> _matches = new List<IMatch>();
        private readonly IMatchSortingStrategy _sortingStrategy;

        public Scoreboard(IMatchSortingStrategy sortingStrategy)
        {
            _sortingStrategy = sortingStrategy; 
        }

        public IMatch StartNewGame(IMatch match)
        {
            _matches.Add(match);
            return match;
        }

        public void UpdateScore(IMatch match, int home, int away)
        {
            if (!_matches.Contains(match))
            {
                throw new ArgumentException("Match not found in the scoreboard", nameof(match));
            }
            match.UpdateScore(home, away);
        }

        public void FinishGame(IMatch match)
        {
            
            if (!_matches.Remove(match))
            {
                throw new ArgumentException("Match not found in the scoreboard", nameof(match));
            }
        }

        public IList<IMatch> GetInProgressGames()
        {
            return _sortingStrategy.Sort(_matches);
        }
    }

}