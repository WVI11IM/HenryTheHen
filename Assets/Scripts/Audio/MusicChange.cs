using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public string levelMusic;
    // Start is called before the first frame update
    void Start()
    {
        if (levelMusic == "song1")
        {
            Debug.Log("song1");
            AudioManager.Instance.PlayMusic1("song1");
        }
        else if (levelMusic == "song2")
        {
            Debug.Log("song2");
            AudioManager.Instance.PlayMusic2("song2");
        }
        else if(levelMusic == "menu")
        {
            Debug.Log("menu");
            AudioManager.Instance.PlayMenuMusic("menu");
        }
    }
}
