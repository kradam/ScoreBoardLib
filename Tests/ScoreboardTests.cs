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
            const string homeTeam = "Home";
            const string awayTeam = "Away";

            IMatch match = new Match(homeTeam, awayTeam);
            IMatch addedMatch = scoreboard.StartNewGame(match);
            Assert.Equal(match, addedMatch);
            Assert.Contains(match, scoreboard.GetInProgressGames());
        }

        [Fact]
        public void UpdateScore_UpdatesMatchScore()
        {
            IScoreboard scoreboard = new Scoreboard(_sortingStrategy);
            const int HomeScore = 2;
            const int AwayScore = 3;
            const string homeTeam = "Home";
            const string awayTeam = "Away";

            IMatch match = scoreboard.StartNewGame(new Match(homeTeam, awayTeam));

            scoreboard.UpdateScore(match, HomeScore, AwayScore);

            Assert.Equal(HomeScore, match.Score.Home);
            Assert.Equal(AwayScore, match.Score.Away);
        }

        [Fact]
        public void FinishGame_RemovesMatchFromScoreboard()
        {
            IScoreboard scoreboard = new Scoreboard(_sortingStrategy);
            const string homeTeam = "Home";
            const string awayTeam = "Away";
            IMatch match = scoreboard.StartNewGame(new Match(homeTeam, awayTeam));

            scoreboard.FinishGame(match);
            IList<IMatch> inProgressGames = scoreboard.GetInProgressGames();

            Assert.DoesNotContain(match, inProgressGames);

            Assert.Throws<ArgumentException>(() => scoreboard.FinishGame(match));
        }
        
    }

}
