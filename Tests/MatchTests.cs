using Xunit;

namespace ScoreBoardLib
{
    public class MatchTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            string homeTeam = "HomeTeam";
            string awayTeam = "AwayTeam";

            Match match = new (homeTeam, awayTeam);

            Assert.Equal(homeTeam, match.HomeTeam);
            Assert.Equal(awayTeam, match.AwayTeam);
            Assert.Equal((0, 0), match.Score);
        }

        [Fact]
        public void UpdateScore_UpdatesScoreCorrectly()
        {
            Match match = new ("HomeTeam", "AwayTeam");
            int newHomeScore = 3;
            int newAwayScore = 2;

            match.UpdateScore(newHomeScore, newAwayScore);

            Assert.Equal((newHomeScore, newAwayScore), match.Score);
        }

        [Fact]
        public void UpdateScore_ThrowsException_WhenNegativeScoreProvided()
        {
            // Arrange
            Match match = new ("HomeTeam", "AwayTeam");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => match.UpdateScore(-1, 0));
            Assert.Throws<ArgumentException>(() => match.UpdateScore(0, -1));
            Assert.Throws<ArgumentException>(() => match.UpdateScore(-1, -1));
        }
    }
}
