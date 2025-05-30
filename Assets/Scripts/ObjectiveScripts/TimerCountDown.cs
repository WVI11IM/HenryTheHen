using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerCountDown : MonoBehaviour
{
    public Text timerText;
    public Image timeBar;

    public EnemySpawnManager[] enemySpawnManagers;

    public GameObject[] newEnemySpawner;
    
    float countDown;
    public float gameTime;

    public bool hasTutorial;
    public GameObject tutorial;

    void Start()
    {
        timerText.text = countDown.ToString();

        countDown = gameTime;
        Scenes.missionComplete = false;
        Time.timeScale = 1f;

        if (hasTutorial)
        {
            tutorial.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
            {
                tutorial.SetActive(false);
            } 
        }

        if (countDown > 0)
        {
            countDown -= Time.deltaTime;

            int roundedCountDown = (int)countDown;

            timerText.text = roundedCountDown.ToString();

            timeBar.fillAmount = countDown / gameTime;
        }

        if (countDown <= (gameTime - 1) / 3)
        {
            for (int i = 0; i < enemySpawnManagers.Length; i++)
            {
                enemySpawnManagers[i].Faster2();
                for (int n = 0; n < newEnemySpawner.Length; n++)
                {
                    newEnemySpawner[n].SetActive(true);
                }
                print("faster2");
            }
        }
        else if (countDown <= ((gameTime - 1) / 3) * 2)
        {
            for (int i = 0; i < enemySpawnManagers.Length; i++)
            {
                enemySpawnManagers[i].Faster1();
                for (int n = 0; n < newEnemySpawner.Length; n++)
                {
                    newEnemySpawner[n].SetActive(true);
                }
                print("faster1");
            }
        }
        else
        {
            for (int i = 0; i < enemySpawnManagers.Length; i++)
            {
                enemySpawnManagers[i].NormalSpeed();
                for (int n = 0; n < newEnemySpawner.Length; n++)
                {
                    newEnemySpawner[n].SetActive(false);
                }
            }
        }

        if (countDown < 0)
        {
            Scenes.missionComplete = true;
        }

    }
}
