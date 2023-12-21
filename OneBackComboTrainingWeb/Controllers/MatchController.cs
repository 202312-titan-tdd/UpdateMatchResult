#region

using OneBackComboTrainingWeb.Enums;

#endregion

namespace OneBackComboTrainingWeb.Controllers;

public class MatchController
{
    public string UpdateMatchResult(int matchId, EnumAction action)
    {
        var homeScore = "1";
        return $"{homeScore}:0 (First Half)";
    }
}