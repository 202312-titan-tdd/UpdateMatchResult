using OneBackComboTrainingWeb.Domains;

namespace OneBackComboTrainingWeb.Repos;

public interface IMatchRepo
{
    Match GetMatch(int id);
    void UpdateMatchResult(Match match);
}