using System.CodeDom.Compiler;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int level;
    [SerializeField]
    private float minimumSpawnTime;
    [SerializeField]
    private float maximumSpawnTime;
    [SerializeField]
    private Vector2 spawnArea;
    [SerializeField]
    private Rigidbody2D player;

    [SerializeField]
    private GameObject mob1;
    [SerializeField]
    private GameObject mob2;
    [SerializeField]
    private GameObject mob3;
    [SerializeField]
    private GameObject mob4;
    [SerializeField]
    private GameObject mob5;
    [SerializeField]
    private GameObject boss1;

    private bool isWorking;
    private int mobToSpawn;
    private float timer;
    private float timeUntilSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        isWorking = true;
        timer = 0;
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking) {
            SetMobToSpawn();
            timer += Time.deltaTime;
            timeUntilSpawn -= Time.deltaTime;

            if (timeUntilSpawn < 0)
            {
                Spawn();
                if (mobToSpawn == 6)
                {
                    isWorking = false;
                }
            }
        }
    }
    private void Spawn()
    {
        Vector2 position = GenerateRandomPosition() + player.position;
        GameObject enemy = mobToSpawn switch
        {
            1 => Instantiate(mob1, position, Quaternion.identity),
            2 => Instantiate(mob2, position, Quaternion.identity),
            3 => Instantiate(mob3, position, Quaternion.identity),
            4 => Instantiate(mob4, position, Quaternion.identity),
            5 => Instantiate(mob5, position, Quaternion.identity),
            6 => Instantiate(boss1, position, Quaternion.identity),
            _ => Instantiate(mob1, position, Quaternion.identity),
        };
        enemy.GetComponent<Mob_script>().SetTarget(player);
        SetTimeUntilSpawn();
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
        }
        else
        {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        return position;
    }
    private void SetMobToSpawn()
    {
        if (level == 1)
        {
            if (timer <=  60 * 3)
                mobToSpawn = 5;
            else if (timer <= 60 * 6)
                mobToSpawn = 2;
            else if (timer <= 60 * 9)
                mobToSpawn = 3;
            else if (timer <= 60 * 12)
                mobToSpawn = 4;
            else if (timer <= 60 * 15)
                mobToSpawn = 2;
            else if (timer <= 60 * 18)
                mobToSpawn = 1;
            else if (timer <= 60 * 21)
                mobToSpawn = 4;
            else if (timer <= 60 * 24)
                mobToSpawn = 3;
            else if (timer <= 60 * 27)
                mobToSpawn = 2;
            else if (timer < 60 * 30)
                mobToSpawn = 4;
            else if (timer >= 60 * 30)
                mobToSpawn = 6;
        }
    }
}
