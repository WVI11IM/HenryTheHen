using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public GameObject skipButton;

    public string nextScene;
    //AudioSource audioSource;

    private void Awake()
    {
        skipButton.SetActive(false);
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
    }

    private void Start()
    {
        AudioManager.Instance.StopMusic();
    }
    public void ActivateSkipButton()
    {
        skipButton.SetActive(true);
    }

    public void Skip(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);//the scene that you want to load after the video has ended.
    }
}

