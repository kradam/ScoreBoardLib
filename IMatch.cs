namespace ScoreBoardLib
{
    public interface IMatch
    {
        string HomeTeam { get; }
        string AwayTeam { get; }
        (int Home, int Away) Score { get; }
        DateTime StartTime { get; }
        void UpdateScore(int home, int away);
    }
}
