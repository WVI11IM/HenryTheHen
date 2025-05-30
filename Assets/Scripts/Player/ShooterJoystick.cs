using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterJoystick : MonoBehaviour
{

    Vector2 posIni;
    Rigidbody2D playerRb;

    Vector2 dir;
    Transform shooterPosition;

    [Space]
    [Header("Partes do Joystick (Children da Camera")]
    public GameObject j1;
    public GameObject j2;

    [Space]
    [Header("Tipos de Ovos")]
    public GameObject egg0;
    public GameObject egg1;
    public GameObject egg2;
    public GameObject egg3;
    public GameObject egg4;
    public GameObject egg5;

    [Space]
    [Header("Tempo de Ovos")]
    public float powerUp1Time;
    public float powerUp2Time;
    public float powerUp3Time;
    public float powerUp4Time;
    public float powerUp5Time;

    [Space]
    [Header("Stats ativos")]
    public int shooterId = 0;
    GameObject eggType;
    public float recoil;
    private float nextActionTime = 0.0f;
    public float cooldown = 0.3f;
    public bool isShooting;
    public bool canTouch;

    void Start()
    {
        shooterPosition = GetComponent<Transform>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        eggType = egg0;
        isShooting = false;
}

    void Update()
    {
        if (Input.touchCount > 0 && canTouch)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
            {
                posIni = toque.position;
                j1.SetActive(true);
                
                Vector3 posCena1 = Camera.main.ScreenToWorldPoint(posIni);
                posCena1.z = 0;
                j1.transform.position = posCena1;
            }

            if (toque.phase == TouchPhase.Moved || toque.phase == TouchPhase.Stationary)
            {
                dir = toque.position - posIni;
                dir = dir.normalized;
                j2.SetActive(true);

                Vector3 posCena2 = Camera.main.ScreenToWorldPoint(toque.position);
                posCena2.z = 0;
                j2.transform.position = posCena2;

                shooterPosition.right = dir;    //define rotacao do shooter com direcao de swipe
                

                if (Time.time > nextActionTime && Vector2.Distance(posIni, toque.position) > 60)
                {

                    nextActionTime = Time.time + cooldown;
                    Shoot();
                    Recoil(playerRb, dir, recoil);
                }
            }

            if (toque.phase == TouchPhase.Ended)
            {
                dir = new Vector2(0, 0);
                shooterPosition.right = dir;    //define rotacao do shooter com direcao de swipe
                j1.SetActive(false);
                j2.SetActive(false);
                isShooting = false;
            }
        }
    }

    void Shoot()
    {
        Instantiate(eggType, shooterPosition.position, shooterPosition.rotation);
        isShooting = true;
    }

    void Recoil(Rigidbody2D rb, Vector2 d, float r)
    {
        rb.velocity /= 4;
        rb.AddForce(d * r);
    }

    public void SwitchShooterId()
    {
        switch (shooterId)
        {
            default:
                SwitchPowerUp0();
                break;
            case 1:
                SwitchPowerUp1();
                break;
            case 2:
                SwitchPowerUp2();
                break;
            case 3:
                SwitchPowerUp3();
                break;
            case 4:
                SwitchPowerUp4();
                break;
            case 5:
                SwitchPowerUp5();
                break;
        }
    }

    public void SwitchPowerUp0()
    {
        eggType = egg0;
        recoil = 500;
        cooldown = 0.35f;
    }

    public void SwitchPowerUp1()
    {
        eggType = egg1;
        recoil = 350;
        cooldown = 0.15f;
    }

    public void SwitchPowerUp2()
    {
        eggType = egg2;
        recoil = 600;
        cooldown = 0.45f;
    }

    public void SwitchPowerUp3()
    {
        eggType = egg3;
        recoil = 650;
        cooldown = 0.75f;
    }

    public void SwitchPowerUp4()
    {
        eggType = egg4;
        recoil = 450;
        cooldown = 0.4f;
    }
    public void SwitchPowerUp5()
    {
        eggType = egg5;
        recoil = 400;
        cooldown = 0.25f;
    }
}
