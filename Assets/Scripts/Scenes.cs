using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public static bool missionComplete;
    public static bool missionFailed;

    public GameObject PauseUI;
    public GameObject WinUI;
    public GameObject LoseUI;

    Player player;
    [SerializeField] ShooterJoystick playerShooter;

    public string currentLevel;
    public string nextLevel;

    bool soundPlaying = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        missionComplete = false;
        missionFailed = false;
    }

    void Update()
    {
        if (missionComplete && player.isAlive)
        {
            WinSound();
            Win();
        }
        if (missionFailed)
        {
            LoseSound();
            Lose();
        }
    }

    public void Resume()
    {
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        playerShooter.canTouch = true;
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        playerShooter.canTouch = false;

    }

    void Win()
    {
        WinUI.SetActive(true);
        Time.timeScale = 0f;
        playerShooter.canTouch = false;
        player.isInvincible = true;

        Save.Instance.SaveMoney();
    }

    void Lose()
    {
        LoseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; 
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
        PauseUI.SetActive(false);
        missionComplete = false;
        missionFailed = false;
        SceneManager.LoadScene(currentLevel);
    }
    
    public void QuitGame()
    {
        Time.timeScale = 1f;
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
        PauseUI.SetActive(false);
        if (missionComplete)
        {
            Save.Instance.SaveProgress();
            missionComplete = false;
        }
        SceneManager.LoadScene("MENU");
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
        PauseUI.SetActive(false);
        playerShooter.canTouch = true;
        if (missionComplete && player.isAlive)
        {
            Save.Instance.SaveProgress();
            missionComplete = false;
        }
        SceneManager.LoadScene(nextLevel);
    }

    void WinSound()
    {
        if (!soundPlaying)
        {
            AudioManager.Instance.PlaySFX("win", 0.75f);
            soundPlaying = true;
        }
    }

    void LoseSound()
    {
        if (!soundPlaying)
        {
            AudioManager.Instance.PlaySFX("lose", 0.75f);
            soundPlaying = true;
        }
    }
}
