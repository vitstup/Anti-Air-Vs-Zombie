using UnityEngine;
using UnityEngine.Events;

public class ClearSceneBooster : Booster
{
    public static UnityEvent KillAllZombies = new UnityEvent();

    public override void Collect()
    {
        Debug.Log("Kill All Zombies Booster Collected");
        KillAllZombies?.Invoke();
        gameObject.SetActive(false);
    }
}