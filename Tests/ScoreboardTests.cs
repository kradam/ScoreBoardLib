namespace ScoreBoardLib.Tests
{
    using ScoreBoardTable;
    using Xunit;

    public class ScoreboardTests
    {
        private readonly IMatchSortingStrategy _sortingStrategy = new DefaultMatchSortingStrategy();

        [Fact]
        public void StartNewGame_AddsNewMatchToScoreboard()
        {
            IScoreboard scoreboard = new Scoreboard(_sortingStrategy);
            string homeTeam = "Home";
            string awayTeam = "Away";

            IMatch newMatch = scoreboard.StartNewGame(homeTeam, awayTeam);

            // Assert
            Assert.Equal(homeTeam, newMatch.HomeTeam);
            Assert.Equal(awayTeam, newMatch.AwayTeam);
        }
    }

}
