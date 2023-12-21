#region

using FluentAssertions;
using NSubstitute;
using OneBackComboTrainingWeb.Controllers;
using OneBackComboTrainingWeb.Domains;
using OneBackComboTrainingWeb.Enums;
using OneBackComboTrainingWeb.Repos;

#endregion

namespace OneBackTests;

[TestFixture]
public class MatchControllerTests
{
    private MatchController _matchController = null!;
    private IMatchRepo _matchRepo = null!;

    [SetUp]
    public void SetUp()
    {
        _matchRepo = Substitute.For<IMatchRepo>();
        _matchController = new MatchController(_matchRepo);
    }

    [Test]
    public void home_goal_when_0_0_first_half()
    {
        GivenMatchResultFromRepo("");
        AfterActionDisplayResultShouldBe(EnumAction.HomeGoal, "1:0 (First Half)");
        ShouldUpdateMatchResult("H");
    }

    [Test]
    public void away_goal()
    {
        GivenMatchResultFromRepo("H");
        AfterActionDisplayResultShouldBe(EnumAction.AwayGoal, "1:1 (First Half)");
        ShouldUpdateMatchResult("HA");
    }

    [Test]
    public void next_period()
    {
        GivenMatchResultFromRepo("HA");
        AfterActionDisplayResultShouldBe(EnumAction.NextPeriod, "1:1 (Second Half)");
        ShouldUpdateMatchResult("HA;");
    }

    [Test]
    public void cancel_home_goal()
    {
        GivenMatchResultFromRepo("HA;H");
        AfterActionDisplayResultShouldBe(EnumAction.CancelHomeGoal, "1:1 (Second Half)");
        ShouldUpdateMatchResult("HA;");
    }

    [Test]
    public void cancel_1st_half_last_home_goal_when_2nd_half_start()
    {
        GivenMatchResultFromRepo("HAH;");
        AfterActionDisplayResultShouldBe(EnumAction.CancelHomeGoal, "1:1 (Second Half)");
        ShouldUpdateMatchResult("HA;");
    }

    private void ShouldUpdateMatchResult(string matchResult)
    {
        _matchRepo.Received()
                  .UpdateMatchResult(Arg.Is<Match>(match => match.MatchResult.GetResult() == matchResult));
    }

    private void AfterActionDisplayResultShouldBe(EnumAction action, string expected)
    {
        var displayResult = _matchController.UpdateMatchResult(91, action);
        displayResult.Should().Be(expected);
    }

    private void GivenMatchResultFromRepo(string matchResult)
    {
        _matchRepo.GetMatch(91)
                  .Returns(new Match { Id = 91, MatchResult = new MatchResult(matchResult) });
    }
}