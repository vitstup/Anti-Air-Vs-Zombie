using UnityEngine;

public abstract class Upgrade
{
    [field: SerializeField] public int price { get; private set; }

    public bool CanUpgrade(int points)
    {
        return points >= price;
    }

    public abstract void DoUpgrade();
}