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