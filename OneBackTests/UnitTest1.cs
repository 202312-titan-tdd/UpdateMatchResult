using FluentAssertions;
using OneBackComboTrainingWeb.Controllers;
using OneBackComboTrainingWeb.Enums;

namespace OneBackTests;

[TestFixture]
public class MatchControllerTests
{

    [Test]
    public void home_goal()
    {
        var matchController = new MatchController();
        int matchId=91;
        var updateMatchResult = matchController.UpdateMatchResult(matchId, EnumAction.HomeGoal);
        updateMatchResult.Should().Be("1:0 (First Half)");
    }
}