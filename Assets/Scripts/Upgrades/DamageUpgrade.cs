using UnityEngine;

[System.Serializable]
public class DamageUpgrade : GunUpgrade
{
    [SerializeField] private float additionalDamage;

    public DamageUpgrade(AbstractGun gun) : base(gun)
    {

    }

    public override void DoUpgrade()
    {
        gun.AddDamage(additionalDamage);
    }
}