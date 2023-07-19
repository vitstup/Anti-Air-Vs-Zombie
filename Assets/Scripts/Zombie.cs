using UnityEngine;
using UnityEngine.Events;

public class Zombie : MonoBehaviour, Idieble
{
    public static UnityEvent zombieKilled = new UnityEvent();

    [SerializeField, Range(0.5f, 10f)] private float health;
    [SerializeField, Range(0.1f, 1f)] private float speed;

    [SerializeField] private float activeTimeAfterDeath;

    private float currentHealth;

    private float currentActiveTime;

    private Animator animator;

    private Collider collider;

    public bool isDead { get; private set; }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        collider = GetComponent<Collider>();

        ClearSceneBooster.KillAllZombies.AddListener(ClearBoosterUsed);
    }

    private void Start()
    {
        currentHealth = health;
        animator.SetFloat("MovementSpeed", speed);
    }

    private void Update()
    {
        if (!isDead)
        {
            transform.Translate(Vector3.back * speed * 1.5f * Time.deltaTime);
        }
        else
        {
            currentActiveTime += Time.deltaTime;
            if (currentActiveTime >= activeTimeAfterDeath) 
            {
                currentActiveTime = 0;
                gameObject.SetActive(false);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
            if (currentHealth <= 0) Die();
        }
    }

    public void Die()
    {
        animator.SetBool("IsDead", true);
        isDead = true;
        zombieKilled?.Invoke();

        collider.enabled = false;
    }

    public void Alive()
    {
        animator.SetBool("IsDead", false);
        isDead = false;

        collider.enabled = true;
    }

    private void ClearBoosterUsed()
    {
        if(!isDead && gameObject.activeSelf) Die();
    }
}