using UnityEngine;
using UnityEngine.Events;

public class FreezeSpawningBooster : Booster
{
    public class FloatEvent : UnityEvent<float> { }
    public static FloatEvent FreezeSpawn = new FloatEvent();

    [SerializeField] private float freezeTime;

    public override void Collect()
    {
        Debug.Log("Freeze Spawning Booster Collected");
        FreezeSpawn?.Invoke(freezeTime);
        gameObject.SetActive(false);
    }
}