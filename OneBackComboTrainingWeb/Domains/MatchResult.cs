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
        return $"{homeScore}:0 (First Half)";
    }

    public string GetResult()
    {
        return _matchResult;
    }

    public void HomeGoal()
    {
        _matchResult += "H";
    }
}