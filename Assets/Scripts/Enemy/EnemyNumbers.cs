using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNumbers : MonoBehaviour
{
    public static int enemyTotal;
    public int enemyLimit;

    public GameObject[] enemySpawners;

    void Start()
    {
        enemyTotal = 0;
    }

    void Update()
    {
        if (enemyTotal < enemyLimit)
        {
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].SetActive(false);
            }
        }
    }
}
