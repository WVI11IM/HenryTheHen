using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScenes : MonoBehaviour
{
    public Animator animatorMenu;
    public GameObject options;
    public Animator animatorSkin1;
    public Animator animatorSkin2;
    public Animator animatorSkin3;
    public GameObject skin1;
    public GameObject skin2;
    public GameObject skin3;

    [Space]
    public GameObject button01;
    public GameObject button02;
    public GameObject button10;
    public GameObject button11;
    public GameObject button12;
    public GameObject button20;
    public GameObject button21;
    public GameObject button22;
    public GameObject button30;
    public GameObject button31;
    public GameObject button32;
    [Space]

    public GameObject level11;
    public GameObject level12;
    public GameObject level13;
    public GameObject level21;
    public GameObject level22;
    public GameObject level23;

    int currentLevel;

    void Awake()
    {
        Time.timeScale = 1f;

        options.SetActive(false);
        skin1.SetActive(false);
        skin2.SetActive(false);
        skin3.SetActive(false);

        currentLevel = PlayerPrefs.GetInt("prefLevel");

        level11.SetActive(false);
        level12.SetActive(false);
        level13.SetActive(false);
        level21.SetActive(false);
        level22.SetActive(false);
        level23.SetActive(false);
        LevelImage();

        if(PlayerPrefs.GetInt("skin1") == 1)
        {
            button11.SetActive(true);
        }

        if (PlayerPrefs.GetInt("skin2") == 1)
        {
            button21.SetActive(true);
        }

        if (PlayerPrefs.GetInt("skin3") == 1)
        {
            button31.SetActive(true);
        }

        if (PlayerPrefs.GetInt("skinEquipped") == 3)
        {
            button02.SetActive(false);
            button12.SetActive(false);
            button22.SetActive(false);
            button32.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("skinEquipped") == 2)
        {
            button02.SetActive(false);
            button12.SetActive(false);
            button22.SetActive(true);
            button32.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("skinEquipped") == 1)
        {
            button02.SetActive(false);
            button12.SetActive(true);
            button22.SetActive(false);
            button32.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("skinEquipped") == 0)
        {
            button02.SetActive(true);
            button12.SetActive(false);
            button22.SetActive(false);
            button32.SetActive(false);
        }

        animatorMenu.SetBool("onMenu", true);
        options.SetActive(false);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        if (currentLevel == 12)
        {
            SceneManager.LoadScene("LEVEL1-2");
        }
        else if(currentLevel == 13)
        {
            SceneManager.LoadScene("LEVEL1-3");
        }
        else if(currentLevel == 21)
        {
            SceneManager.LoadScene("LEVEL2-1");
        }
        else if(currentLevel == 22)
        {
            SceneManager.LoadScene("LEVEL2-2");
        }
        else if(currentLevel == 23)
        {
            SceneManager.LoadScene("LEVEL2-3");
        }

        else
        {
            SceneManager.LoadScene("CUTSCENE1"); //<===================
        }
        //else
        //{
        //    SceneManager.LoadScene("LEVEL1-1");
        //}
    }

    public void Options()
    {
        options.SetActive(true);
    }
    
    public void Shop()
    {
        animatorMenu.SetBool("onMenu", false);
        skin1.SetActive(false);
        skin2.SetActive(false);
        skin3.SetActive(false);
    }

    public void ShopEquip0()
    {
    button02.SetActive(true);
    button12.SetActive(false);
    button22.SetActive(false);
    button32.SetActive(false);
    PlayerPrefs.SetInt("skinEquipped", 0);
    }
    public void ShopDetail1()
    {
        skin1.SetActive(true);
        animatorSkin1.SetBool("shopDetail", true);
    }
    public void ShopBuy1()
    {
        if (PlayerPrefs.GetInt("prefMoney") >= 10)   //<================
        {
            Save.Instance.AddMoney(-10);
            Save.Instance.SaveMoney();
            button11.SetActive(true);
            skin1.SetActive(false);
            PlayerPrefs.SetInt("skin1", 1);
            AudioManager.Instance.PlaySFX("clickBuy", 1f);
        }
        else
        {
            print("nope");
        }
    }

    public void ShopEquip1()
    {
        button02.SetActive(false);
        button12.SetActive(true);
        button22.SetActive(false);
        button32.SetActive(false);
        PlayerPrefs.SetInt("skinEquipped", 1);
    }

    public void ShopDetail2()
    {
        skin2.SetActive(true);
        animatorSkin2.SetBool("shopDetail", true);
    }
    public void ShopBuy2()
    {
        if (PlayerPrefs.GetInt("prefMoney") >= 20)
        {
            Save.Instance.AddMoney(-20);
            Save.Instance.SaveMoney();
            button21.SetActive(true);
            skin2.SetActive(false);
            PlayerPrefs.SetInt("skin2", 1);
            AudioManager.Instance.PlaySFX("clickBuy", 1f);
        }
    }

    public void ShopEquip2()
    {
        button02.SetActive(false);
        button12.SetActive(false);
        button22.SetActive(true);
        button32.SetActive(false);
        PlayerPrefs.SetInt("skinEquipped", 2);
    }
    public void ShopDetail3()
    {
        skin3.SetActive(true);
        animatorSkin3.SetBool("shopDetail", true);
    }
    public void ShopBuy3()
    {
        if (PlayerPrefs.GetInt("prefMoney") >= 30)
        {
            Save.Instance.AddMoney(-30);
            Save.Instance.SaveMoney();
            button31.SetActive(true);
            skin3.SetActive(false);
            PlayerPrefs.SetInt("skin3", 1);
            AudioManager.Instance.PlaySFX("clickBuy", 1f);
        }
    }

    public void ShopEquip3()
    {
        button02.SetActive(false);
        button12.SetActive(false);
        button22.SetActive(false);
        button32.SetActive(true);
        PlayerPrefs.SetInt("skinEquipped", 3);
    }

    public void Menu()
    {
        animatorMenu.SetBool("onMenu", true);
        options.SetActive(false);
    }
    public void LevelImage()
    {
        if (currentLevel == 12)
        {
            level12.SetActive(true);
        }
        else if (currentLevel == 13)
        {
            level13.SetActive(true);
        }
        else if (currentLevel == 21)
        {
            level21.SetActive(true);
        }
        else if (currentLevel == 22)
        {
            level22.SetActive(true);
        }
        else if (currentLevel == 23)
        {
            level23.SetActive(true);
        }

        else
        {
            level11.SetActive(true);
        }
    }
}
