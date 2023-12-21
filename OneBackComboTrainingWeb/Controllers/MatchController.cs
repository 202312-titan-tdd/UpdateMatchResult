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
        
        return GetDisplayResult();
    }

    private static string GetDisplayResult()
    {
        var homeScore = "1";
        return $"{homeScore}:0 (First Half)";
    }
}