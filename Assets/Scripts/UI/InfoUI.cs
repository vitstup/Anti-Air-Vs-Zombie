using TMPro;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI zombiesText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private TextMeshProUGUI damageText;

    public void SetScoreText(int score)
    {
        scoreText.text = "Score " + score;
    }

    public void SetZombiesText(int zombies)
    {
        zombiesText.text = "Zombies left " + zombies;
    }

    public void SetRpmText(int rpm)
    {
        rpmText.text = "Rpm " + rpm;
    }

    public void SetDamageText(float damage)
    {
        damageText.text = "Damage " + damage.ToString();
    }
}
