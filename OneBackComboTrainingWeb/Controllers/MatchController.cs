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
        switch (action)
        {
            case EnumAction.HomeGoal:
                match.MatchResult.HomeGoal();
                break;
            case EnumAction.AwayGoal:
                match.MatchResult.AwayGoal();
                break;
        }

        _matchRepo.UpdateMatchResult(match);

        return match.MatchResult.GetDisplayResult();
    }
}