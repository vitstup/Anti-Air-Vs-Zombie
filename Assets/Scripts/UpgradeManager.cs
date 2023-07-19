using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private AbstractGun gun;
    [SerializeField] private InfoUI infoUI;
    [SerializeField] private UpgradeUI upgradeUI;

    [Header("Upgrades")]
    [SerializeField] private RpmUpgrade[] rpmUpgrades;
    private int currentRpmUpgrade;

    [SerializeField] private DamageUpgrade[] damageUpgrades;
    private int currentDamageUpgrade;

    private void Start()
    {
        InitializeUpgrades();

        infoUI.SetRpmText(gun.GetRpm());
        infoUI.SetDamageText(gun.GetDamage());

        UpdateUpgradeUI();
    }

    private void InitializeUpgrades()
    {
        foreach (var rpm in rpmUpgrades)
        {
            rpm.SetGun(gun);
        }
        foreach (var damage in damageUpgrades)
        {
            damage.SetGun(gun);
        }
    }

    public void DoRpmUpgrade()
    {
        RpmUpgrade upgrade = rpmUpgrades[currentRpmUpgrade];
        if (upgrade.CanUpgrade(scoreManager.score))
        {
            scoreManager.LoseSomeScore(upgrade.price);
            upgrade.DoUpgrade();

            currentRpmUpgrade++;

            infoUI.SetRpmText(gun.GetRpm());

            UpdateUpgradeUI();
        }
    }

    public void DoDamageUpgrade()
    {
        DamageUpgrade upgrade = damageUpgrades[currentDamageUpgrade];
        if (upgrade.CanUpgrade(scoreManager.score))
        {
            scoreManager.LoseSomeScore(upgrade.price);
            upgrade.DoUpgrade();

            currentDamageUpgrade++;

            infoUI.SetDamageText(gun.GetDamage());

            UpdateUpgradeUI();
        }
    }

    private void UpdateUpgradeUI()
    {
        RpmUpgrade rpmUpgrade = currentRpmUpgrade < rpmUpgrades.Length ? rpmUpgrades[currentRpmUpgrade] : null;
        DamageUpgrade damageUpgrade = currentDamageUpgrade < damageUpgrades.Length ? damageUpgrades[currentDamageUpgrade] : null;

        upgradeUI.UpdateInfo(rpmUpgrade, damageUpgrade);
    }
}
