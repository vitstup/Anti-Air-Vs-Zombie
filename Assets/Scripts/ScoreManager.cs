using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private InfoUI infoUI;
    [SerializeField] private LoseManager loseManager;

    [Header("Lose Conditions")]
    [SerializeField] private bool zombiesInSceneCondition;
    [SerializeField, Range(5, 20)] private int zombiesInSceneToLose;

    [SerializeField] private bool scoreCondition;
    [SerializeField, Range(-100, -1)] private int scoreToLose;

    public int score { get; private set; }
    public int zombiesAmount { get; private set; }

    private void Awake()
    {
        EnemySpawner.zombieSpawned.AddListener(ZombieSpawned);
        Zombie.zombieKilled.AddListener(ZombieKilled);
        ZombieEscapeHandler.ZombieBreakthrough.AddListener(ZombieEscaped);
    }

    private void Start()
    {
        infoUI.SetZombiesText(zombiesAmount);
        infoUI.SetScoreText(score);
    }

    public void LoseSomeScore(int score)
    {
        this.score -= score;
        infoUI.SetScoreText(this.score);
    }

    private void ZombieSpawned()
    {
        zombiesAmount++;

        infoUI.SetZombiesText(zombiesAmount);

        LoseCheck();
    }

    private void ZombieKilled()
    {
        zombiesAmount--;
        score++;

        infoUI.SetZombiesText(zombiesAmount);
        infoUI.SetScoreText(score);

        TryToSaveBestScorez();
    }

    private void ZombieEscaped()
    {
        zombiesAmount--;
        score--;

        infoUI.SetZombiesText(zombiesAmount);
        infoUI.SetScoreText(score);

        LoseCheck();
    }

    private void LoseCheck()
    {
        if (zombiesInSceneCondition && zombiesAmount >= zombiesInSceneToLose) loseManager.Lose();
        if (scoreCondition && score <= scoreToLose) loseManager.Lose();
    }

    private void TryToSaveBestScorez()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            int maxScore = PlayerPrefs.GetInt("Score");
            if (score > maxScore) PlayerPrefs.SetInt("Score", score);
        }
        else PlayerPrefs.SetInt("Score", score);
    }
}