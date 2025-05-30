using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    //limites de swipe
    float min = 100;
    float max = 1700;
    float tmin = 0.05f;
    float tmax = 0.55f;

    Vector2 posIni;
    float tempoIni;
    Rigidbody2D playerRb;
    public Vector2 dir;
    public Transform shooterPosition;
   
    public int shooterId;
    public GameObject egg;
    public float recoil;
    //public float rate;

    private float nextActionTime = 0.0f;
    public float period = 1; //MUDAR?

    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
            {
                posIni = toque.position;
                tempoIni = Time.realtimeSinceStartup;
                //guardando valores iniciais
            }
            if (toque.phase == TouchPhase.Ended)
            {
                float dist = Vector2.Distance(toque.position, posIni);
                float tempo = Time.realtimeSinceStartup - tempoIni;
                //calculando distancia e tempo entre posicoes

                if (dist >= min && dist <= max && tempo >= tmin && tempo <= tmax)
                {
                    dir = toque.position - posIni;
                    dir = dir.normalized;

                    shooterPosition.right = dir;    //define rotacao do shooter com direcao de swipe
                }
            }
        }

        if (Time.time > nextActionTime)
        {
            
            nextActionTime += period;
            Shoot();
            Recoil(playerRb, dir, recoil);
        }

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
