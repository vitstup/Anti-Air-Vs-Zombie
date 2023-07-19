using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [Header("Rpm")]
    [SerializeField] private Button rpmUpgradeBtn;
    [SerializeField] private TextMeshProUGUI rpmUpgradeScoreText;

    [Header("Damage")]
    [SerializeField] private Button damageUpgradeBtn;
    [SerializeField] private TextMeshProUGUI damageUpgradeScoreText;

    public void UpdateInfo(RpmUpgrade rpmUpgrade, DamageUpgrade damageUpgrade)
    {
        if (rpmUpgrade != null) rpmUpgradeScoreText.text = "Price " + rpmUpgrade.price;
        else rpmUpgradeBtn.interactable = false;

        if (damageUpgrade != null) damageUpgradeScoreText.text = "Price " + damageUpgrade.price;
        else damageUpgradeBtn.interactable = false;
    }
}