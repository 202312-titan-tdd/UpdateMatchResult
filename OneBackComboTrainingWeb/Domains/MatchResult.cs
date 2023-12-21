#region

using OneBackComboTrainingWeb.Enums;
using OneBackComboTrainingWeb.Exceptions;

#endregion

namespace OneBackComboTrainingWeb.Domains;

public class MatchResult
{
    private string _matchResult;

    public MatchResult(string matchResult)
    {
        _matchResult = matchResult;
    }

    public string GetDisplayResult()
    {
        var homeScore = _matchResult.Count(c => c == 'H');
        var awayScore = _matchResult.Count(c => c == 'A');
        var period = _matchResult.Contains(';') ? "Second" : "First";
        return $"{homeScore}:{awayScore} ({period} Half)";
    }

    public string GetResult()
    {
        return _matchResult;
    }

    public void UpdateBy(EnumAction action)
    {
        switch (action)
        {
            case EnumAction.HomeGoal:
                HomeGoal();
                break;
            case EnumAction.AwayGoal:
                AwayGoal();
                break;
            case EnumAction.NextPeriod:
                NextPeriod();
                break;
            case EnumAction.CancelHomeGoal:
                CancelHomeGoal();
                break;
            case EnumAction.CancelAwayGoal:
                CancelAwayGoal();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, null);
        }
    }

    private void AwayGoal()
    {
        _matchResult += "A";
    }

    private void CancelAwayGoal()
    {
        CancelGoal('A');
    }

    private void CancelGoal(char team)
    {
        var isNextPeriod = false;
        if (_matchResult.EndsWith(';'))
        {
            isNextPeriod = true;
            _matchResult = _matchResult[..^1];
        }

        if (_matchResult.EndsWith(team))
        {
            _matchResult = _matchResult[..^1] + (isNextPeriod ? ";" : "");
        }
        else
        {
            throw new MatchResultException() { MatchResult = this };
        }
    }

    private void CancelHomeGoal()
    {
        CancelGoal('H');
    }

    private void HomeGoal()
    {
        _matchResult += "H";
    }

    private void NextPeriod()
    {
        _matchResult += ";";
    }
}