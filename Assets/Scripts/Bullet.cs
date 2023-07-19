using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    [SerializeField, Range(10f, 60f)] private float maxLiveTime;

    private float currentLiveTime;

    private float additionalDamage;

    public void Shooted(Transform from, float additionalDamage)
    {
        transform.position = from.position;
        transform.rotation = from.rotation;

        currentLiveTime = maxLiveTime;

        this.additionalDamage = additionalDamage;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        currentLiveTime -= Time.deltaTime;

        if (currentLiveTime <= 0) DeActivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Idamagable>(out Idamagable damagable))
        {
            damagable.TakeDamage(damage + additionalDamage);
        }
        if (other.TryGetComponent<Booster>(out Booster booster))
        {
            booster.Collect();
        }
        DeActivate();
    }

    private void DeActivate()
    {
        gameObject.SetActive(false);
    }

    public float GetBaseDamage() => damage;
    public float GetTotalDamage() => damage + additionalDamage;
}