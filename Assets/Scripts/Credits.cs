using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMenuMusic("menu");
    }

    public void Skip(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
