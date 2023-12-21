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
    [Test]
    public void home_goal()
    {
        var matchRepo = Substitute.For<IMatchRepo>();
        var matchController = new MatchController(matchRepo);

        matchRepo.GetMatch(91)
                 .Returns(new Match { Id = 91, MatchResult = new MatchResult("") });

        var updateMatchResult = matchController.UpdateMatchResult(91, EnumAction.HomeGoal);
        updateMatchResult.Should().Be("1:0 (First Half)");

        matchRepo.Received()
                 .UpdateMatchResult(Arg.Is<Match>(match => match.MatchResult.GetResult() == "H"));
    }
}