namespace ScoreBoardLib
{
    using System;
    using System.Collections.Generic;

    public interface IScoreboard
    {
        IMatch StartNewGame(IMatch match);
        void UpdateScore(IMatch match, int home, int away);
        void FinishGame(IMatch match);
        IList<IMatch> GetInProgressGames();
    }
}
