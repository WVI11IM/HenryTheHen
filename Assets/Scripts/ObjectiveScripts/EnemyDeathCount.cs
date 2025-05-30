using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyDeathCount : MonoBehaviour
{
    public Text enemyDeathCountText;

    public EnemySpawnManager[] enemySpawnManagers;

    public GameObject newEnemySpawner;

    public static int enemyCount;
    public int enemyGoal;

    void Start()
    {
        enemyDeathCountText.text = enemyCount.ToString() + "/" + enemyGoal.ToString();

        enemyCount = 0;
        Scenes.missionComplete = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (enemyCount >= (enemyGoal / 3) * 2)
        {
            for (int i = 0; i < enemySpawnManagers.Length; i++)
            {
                enemySpawnManagers[i].Faster2();
                newEnemySpawner.SetActive(true);
            }
        }
        else if (enemyCount >= enemyGoal / 3)
        {
            for (int i = 0; i < enemySpawnManagers.Length; i++)
            {
                enemySpawnManagers[i].Faster1();
                newEnemySpawner.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < enemySpawnManagers.Length; i++)
            {
                enemySpawnManagers[i].NormalSpeed();
                newEnemySpawner.SetActive(false);
            }
        }

        enemyDeathCountText.text = enemyCount.ToString() + "/" + enemyGoal.ToString();

        if (enemyCount >= enemyGoal)
        {
            Scenes.missionComplete = true;
        }

    }
}
