using System.CodeDom.Compiler;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float minimumSpawnTime;
    [SerializeField]
    private float maximumSpawnTime;
    [SerializeField]
    private Vector2 spawnArea;
    [SerializeField]
    private Rigidbody2D player;

    private float timeUntilSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn < 0)
        {
            Vector2 position = GenerateRandomPosition() + player.position;
            GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            enemy.GetComponent<Mob_script>().SetTarget(player);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }

    private Vector2 GenerateRandomPosition()
    {
        Vector2 position = new Vector2();
        float f = Random.value > 0.5f ? -1f : 1f;
        if (Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        } else
        {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        return position;
    }
}
