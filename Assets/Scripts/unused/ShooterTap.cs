using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTap : MonoBehaviour
{
    Vector2 pos;
    Rigidbody2D playerRb;
    public Vector2 dir;
    public Transform shooterPosition;

    public GameObject j2;

    public int shooterId;
    public GameObject egg;
    public float recoil;
    //public float rate;

    private float nextActionTime = 0.0f;
    public float cooldown = 0.5f;

    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            if (Time.time > nextActionTime)
            {


                if (toque.phase == TouchPhase.Began)
                {
                    pos = toque.position;
                    dir.x = Camera.main.ScreenToWorldPoint(pos).x - shooterPosition.position.x;
                    dir.y = Camera.main.ScreenToWorldPoint(pos).y - shooterPosition.position.y;
                    dir = dir.normalized;

                    j2.SetActive(true);

                    Vector3 posCena2 = Camera.main.ScreenToWorldPoint(toque.position);
                    posCena2.z = 0;
                    j2.transform.position = posCena2;

                    Shoot();
                    Recoil(playerRb, dir, recoil);
                    nextActionTime = Time.time + cooldown;

                    shooterPosition.right = dir;    //define rotacao do shooter com direcao de swipe
                }
            }

            if (toque.phase == TouchPhase.Ended)
            {
                j2.SetActive(false);
            }

        }

        //if (Time.time > nextActionTime)
        //{
        //    nextActionTime += period;
        //    Shoot();
        //    Recoil(playerRb, dir, recoil);
        //}

    }

    void Shoot()
    {
        Instantiate(egg, shooterPosition.position, shooterPosition.rotation);
    }

    void Recoil(Rigidbody2D rb, Vector2 d, float r)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(d * -1 * r);
    }

    void SwitchShooterId()
    {
        switch (shooterId)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
    
}
