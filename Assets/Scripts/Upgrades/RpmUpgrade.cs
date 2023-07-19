using UnityEngine;

[System.Serializable]
public class RpmUpgrade : GunUpgrade
{
    [SerializeField] private int rpm;

    public RpmUpgrade(AbstractGun gun) : base(gun)
    {

    }

    public override void DoUpgrade()
    {
        gun.AddRpm(rpm);
    }
}