using TMPro;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxScoreText;

    private void Start()
    {
        Time.timeScale = 1f;
        SetMaxScoreText();
    }

    private void SetMaxScoreText()
    {
        int score = 0;
        if (PlayerPrefs.HasKey("Score")) score = PlayerPrefs.GetInt("Score");

        maxScoreText.text = "Max Score " + score;
    }

    public void Exit()
    {
        Application.Quit();
    }
}