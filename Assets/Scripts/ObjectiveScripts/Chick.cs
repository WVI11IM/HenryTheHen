using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Chick : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator animator;
    AIPath aipath;
    public bool isFound = false;

    public ChickCount chickCount;
    //public GameObject hearts;

    //public Transform position;

    Player player;

    void Start()
    {
        aipath = GetComponent<AIPath>();
        aipath.canMove = false;

        player = GameObject.Find("Player").GetComponent<Player>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isFound)
        {
            if (player.hasChick == false)
            {
                animator.SetTrigger("isFound");
                aipath.canMove = true;
                isFound = true;
                player.hasChick = true;
                AudioManager.Instance.PlaySFX("chickFound", 0.15f);
                AudioManager.Instance.PlaySFX("chickCry", 0.9f);
            }
            else if (player.hasChick == true)
            {
                player.HasChickText();
            }
            
        }

        if (collision.CompareTag("Coop") && isFound)
        {
            //Instantiate(hearts, position);
            player.hasChick = false;
            ChickCount.chickCount += 1;
            AudioManager.Instance.PlaySFX("chickReturned", 0.15f);
            Destroy(gameObject);
        }
    }
}
