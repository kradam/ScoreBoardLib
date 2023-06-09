﻿namespace ScoreBoardLib.Tests
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

        [Fact]
        public void GetInProgressGames_ReturnsOrderedMatches()
        {
            IScoreboard scoreboard = new Scoreboard(_sortingStrategy);

            IMatch match1 = new Match("#1_Home", "#1_Away");
            IMatch match2 = new Match("#2_Home", "#2_Away");
            IMatch match3 = new Match("#3_Home", "#3_Away");
            IMatch match4 = new Match("#4_Home", "#4_Away");

            scoreboard.StartNewGame(match1);
            scoreboard.StartNewGame(match2);
            scoreboard.StartNewGame(match3);
            scoreboard.StartNewGame(match4);

            scoreboard.UpdateScore(match1, 1, 0);
            scoreboard.UpdateScore(match2, 2, 2);
            scoreboard.UpdateScore(match3, 0, 1);

            scoreboard.FinishGame(match4); 

            var inProgressGames = scoreboard.GetInProgressGames();

            Assert.Equal(3, inProgressGames.Count);
            Assert.Equal(match2, inProgressGames[0]);
            Assert.Equal(match3, inProgressGames[1]);
            Assert.Equal(match1, inProgressGames[2]);
        }
    }
}
