using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public static Save Instance;

    [SerializeField] private int currentMoney;
    [SerializeField] Text[] moneyText;

    public const string prefMoney = "prefMoney";

    int currentLevel;

    public const string prefLevel = "prefLevel";


    private void Awake()
    {
        Instance = this;

        currentMoney = PlayerPrefs.GetInt(prefMoney);
        for(int i = 0; i < moneyText.Length; i++)
        {
            moneyText[i].text = currentMoney.ToString();
        }

        currentLevel = PlayerPrefs.GetInt(prefLevel);
    }

    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        for (int i = 0; i < moneyText.Length; i++)
        {
            moneyText[i].text = currentMoney.ToString();
        }
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt(prefMoney, currentMoney);
    }

    public void SaveProgress()
    {
        if (currentLevel == 23)
        {
            currentLevel = 11;
        }
        else if (currentLevel == 22)
        {
            currentLevel = 23;
        }
        else if (currentLevel == 21)
        {
            currentLevel = 22;
        }
        else if (currentLevel == 13)
        {
            currentLevel = 21;
        }
        else if (currentLevel == 12)
        {
            currentLevel = 13;
        }
        else
        {
            currentLevel = 12;
        }

        PlayerPrefs.SetInt(prefLevel, currentLevel);
    }
}
