using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public static UnityEvent zombieSpawned = new UnityEvent();

    [Header("Dependecies")]
    [SerializeField] private ScoreManager scoreManager;

    [Header("Spawn Area")]
    [SerializeField] private float areaWidth;
    [SerializeField] private float areaLength;

    [Header("Enemies")]
    [SerializeField] private int startEnemiesAmount;
    [SerializeField] private Zombie[] zombies;

    [Header("Spawn Time")]
    [SerializeField, Range(2f, 30f)] private float baseSpawnTime;
    [SerializeField, Range(1f, 15f)] private float hardSpawnTime;
    [SerializeField, Range(10, 100)] private int scoreToHardTime;

    private float currentSpawnTime;
    private float timeTillNextSpawn;

    private float freezeSpawnTimer;

    private EnemyPoolsHandler pools = new EnemyPoolsHandler();

    private void Awake()
    {
        FreezeSpawningBooster.FreezeSpawn.AddListener(StopSpawning);
    }

    private void Start()
    {
        currentSpawnTime = baseSpawnTime;
        for (int i = 0; i < startEnemiesAmount; i++)
        {
            SpawnRandomEnemy();
        }
    }

    private void Update()
    {
        if (freezeSpawnTimer > 0) freezeSpawnTimer -= Time.deltaTime;
        else timeTillNextSpawn -= Time.deltaTime;

        if (timeTillNextSpawn <= 0 && freezeSpawnTimer <= 0)
        {
            CalculateSpawnTime();
            timeTillNextSpawn = currentSpawnTime;
            SpawnRandomEnemy();
        }
    }

    private void SpawnRandomEnemy()
    {
        SpawnEnemy(zombies[Random.Range(0, zombies.Length)]);
    }

    private void SpawnEnemy(Zombie prefab)
    {
        var zombie = pools.GetZombie(prefab);
        zombie.transform.position = GetRandomPosition();
        zombie.Alive();

        zombieSpawned?.Invoke();
    }

    private Vector3 GetRandomPosition()
    {
        float minX = transform.position.x - areaWidth / 2f;
        float maxX = transform.position.x + areaWidth / 2f;

        float minZ = transform.position.z - areaWidth / 2f;
        float maxZ = transform.position.z + areaWidth / 2f;

        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);

        return new Vector3(x, 0, z);
    }

    private void CalculateSpawnTime()
    {
        float percent = (float)scoreManager.score / scoreToHardTime;
        if (percent < 0f) percent = 0f;
        else if (percent > 1f) percent = 1f;

        float lesserTime = (baseSpawnTime - hardSpawnTime) * percent;

        currentSpawnTime = baseSpawnTime - lesserTime;

        Debug.Log("current time beetwen spaws " + currentSpawnTime);
    }

    private void StopSpawning(float time)
    {
        freezeSpawnTimer += time;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaWidth, 5f, areaLength));
    }
}
