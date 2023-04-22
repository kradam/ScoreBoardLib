using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardLib
{
    public class Match : IMatch
    {
        public string HomeTeam { get; }
        public string AwayTeam { get; }
        public (int Home, int Away) Score { get; private set; }
        public DateTime StartTime { get; }

        public Match(string homeTeam, string awayTeam, DateTime startTime)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Score = (0, 0);
            StartTime = startTime;
        }

        public void UpdateScore(int home, int away)
        {
            //ensure home and away are not negative
            if (home < 0 || away < 0)
            {
                throw new ArgumentException("Score cannot be negative");
            }
            Score = (home, away);
        }
    }

}
