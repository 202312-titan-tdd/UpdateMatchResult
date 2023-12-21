#region

using OneBackComboTrainingWeb.Enums;
using OneBackComboTrainingWeb.Repos;

#endregion

namespace OneBackComboTrainingWeb.Controllers;

public class MatchController
{
    private readonly IMatchRepo _matchRepo;

    public MatchController(IMatchRepo matchRepo)
    {
        _matchRepo = matchRepo;
    }

    public string UpdateMatchResult(int matchId, EnumAction action)
    {
        var match = _matchRepo.GetMatch(matchId);
        match.MatchResult.HomeGoal();

        return match.MatchResult.GetDisplayResult();
    }
}