using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpriteFlip : MonoBehaviour
{
    Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (playerRb.velocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void GameOverScreen()
    {
        Scenes.missionFailed = true;
    }

    public void HenryDeathSound()
    {
        AudioManager.Instance.PlaySFX("henryDeath", 0.75f);
    }
    public void HenryDeathSound2()
    {
        AudioManager.Instance.PlaySFX("henryDeath2", 0.75f);
    }
}
