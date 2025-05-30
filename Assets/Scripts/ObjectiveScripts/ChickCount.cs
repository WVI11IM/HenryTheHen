using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChickCount : MonoBehaviour
{
    public Text chickCountText;

    public GameObject newEnemySpawner;

    public static int chickCount;
    public int chickGoal;

    void Start()
    {
        chickCountText.text = chickCount.ToString() + "/" + chickGoal.ToString();

        chickCount = 0;
        Scenes.missionComplete = false;
        Time.timeScale = 1f;

    }

    void Update()
    {
        chickCountText.text = chickCount.ToString() + "/" + chickGoal.ToString();

        if (chickCount >= (float)chickGoal / 3)
        {
            newEnemySpawner.SetActive(true);
        }
        else newEnemySpawner.SetActive(false);

        if (chickCount >= chickGoal)
        {
            Scenes.missionComplete = true;
        }
    }
}
