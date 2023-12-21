namespace OneBackComboTrainingWeb.Domains;

public class MatchResult
{
    private string _matchResult;

    public MatchResult(string matchResult)
    {
        _matchResult = matchResult;
    }

    public void AwayGoal()
    {
        _matchResult += "A";
    }

    public string GetDisplayResult()
    {
        var homeScore = _matchResult.Count(c => c == 'H');
        var awayScore = _matchResult.Count(c => c == 'A');
        return $"{homeScore}:{awayScore} (First Half)";
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