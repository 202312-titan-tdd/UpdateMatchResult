using OneBackComboTrainingWeb.Domains;

namespace OneBackComboTrainingWeb.Exceptions;

public class MatchResultException : Exception
{
    public MatchResult MatchResult { get; set; }
}