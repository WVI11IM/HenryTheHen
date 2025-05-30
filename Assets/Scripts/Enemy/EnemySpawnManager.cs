using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    Enemy enemyScript;
    public Transform chicken;
    public float spawnCooldown;
    float cooldown;


    void Start()
    {
        enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.isFaster1 = false;
        enemyScript.isFaster2 = false;
    }

    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown > spawnCooldown)
        {
            SpawnEnemies();
            EnemyNumbers.enemyTotal += 1;
            cooldown = 0;
        }
    }

    void SpawnEnemies()
    {
        List<Transform> Pontos = new List<Transform>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Vector2.Distance(chicken.position, spawnPoints[i].position) > 9)
            {
                Pontos.Add(spawnPoints[i]);
            }
        }

        int index = Random.Range(0, Pontos.Count);
        Instantiate(enemy, Pontos[index].position, Quaternion.identity);
    }

    public void Faster1()
    {
        enemyScript.isFaster1 = true;
    }
    public void Faster2()
    {
        enemyScript.isFaster2 = true;
    }

    public void NormalSpeed()
    {
        enemyScript.isFaster1 = false;
        enemyScript.isFaster2 = false;
    }
}
