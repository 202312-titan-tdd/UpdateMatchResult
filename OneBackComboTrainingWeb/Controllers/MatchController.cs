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
            case EnumAction.NextPeriod:
                match.MatchResult.NextPeriod();
                break;
            case EnumAction.CancelHomeGoal:
                match.MatchResult.CancelHomeGoal();
                break;
            case EnumAction.CancelAwayGoal:
                match.MatchResult.CancelAwayGoal();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, null);
        }

        _matchRepo.UpdateMatchResult(match);

        return match.MatchResult.GetDisplayResult();
    }
}