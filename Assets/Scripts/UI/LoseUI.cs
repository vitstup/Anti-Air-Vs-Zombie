using UnityEngine;

public class LoseUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Canvas loseCanvas;

    public void OpenCanvas()
    {
        loseCanvas.gameObject.SetActive(true);
    }
}