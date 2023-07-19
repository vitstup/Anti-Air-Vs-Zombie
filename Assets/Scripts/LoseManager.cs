using UnityEngine;

public class LoseManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private LoseUI loseUI;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void Lose()
    {
        Debug.Log("You lose");
        Time.timeScale = 0f;
        loseUI.OpenCanvas();
    }
}