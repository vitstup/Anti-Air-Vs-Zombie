using UnityEngine;

public abstract class AbstractGun : MonoBehaviour
{
    [SerializeField] protected Bullet bulletPrefab;
    [SerializeField] protected int rpm;

    protected BulletPool bulletPool;

    protected float additionalDamage;

    private float timer;

    protected virtual void Start()
    {
        bulletPool = new BulletPool(bulletPrefab, 5, true);
    }

    public void TryToShoot()
    {
        if (CanShoot())
        {
            ResetTimer();
            Shoot();
        }
    }

    protected abstract void Shoot();

    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    private float TimeBeetwenShoots()
    {
        return 60f / rpm;
    }

    protected void ResetTimer()
    {
        timer = TimeBeetwenShoots();
    }

    protected bool CanShoot()
    {
        return timer <= 0;
    }

    public void AddRpm(int rpm)
    {
        this.rpm += rpm;
    }

    public void AddDamage(float damage)
    {
        additionalDamage += damage;
    }

    public int GetRpm() => rpm;

    public float GetDamage() => bulletPrefab.GetBaseDamage() + additionalDamage;
}