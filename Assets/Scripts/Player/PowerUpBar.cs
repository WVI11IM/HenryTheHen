using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBar : MonoBehaviour
{
    public Image powerUpBarTime;
    public Image invincibilityBarTime;
    public GameObject powerUpBar;
    public GameObject invincibilityBar;
    public GameObject iconPowerUp1;
    public GameObject iconPowerUp2;
    public GameObject iconPowerUp3;
    public GameObject iconPowerUp4;
    public GameObject iconPowerUp5;

    ShooterJoystick shooterType;
    Player player;

    float powerUpCountDown;
    float invincibilityCountDown;

    public bool timerOn = false;
    public bool invincibilityTimerOn = false;

    float powerUpTime;
    float invincibilityTime;

    void Start()
    {
        shooterType = GameObject.Find("Shooter").GetComponent<ShooterJoystick>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        powerUpBar.SetActive(false);
        invincibilityBar.SetActive(false);
        iconPowerUp1.SetActive(false);
        iconPowerUp2.SetActive(false);
        iconPowerUp3.SetActive(false);
        iconPowerUp4.SetActive(false);
        iconPowerUp5.SetActive(false);
    }

    void Update()
    {
        if (powerUpCountDown > 0)
        {
            powerUpBar.SetActive(true);
        }
        else powerUpBar.SetActive(false);

        if (invincibilityCountDown > 0)
        {
            invincibilityBar.SetActive(true);
        }
        else invincibilityBar.SetActive(false);

        PowerUpCountDown();
        InvincibilityCountDown();
    }

    public void ShooterId0Trigger()
    {
        iconPowerUp1.SetActive(false);
        iconPowerUp2.SetActive(false);
        iconPowerUp3.SetActive(false);
        iconPowerUp4.SetActive(false);
        iconPowerUp5.SetActive(false);
    }
    public void ShooterId1Trigger()
    {
        timerOn = true;
        PowerUp1CountDown();
    }
    public void ShooterId2Trigger()
    {
        timerOn = true;
        PowerUp2CountDown();
    }
    public void ShooterId3Trigger()
    {
        timerOn = true;
        PowerUp3CountDown();
    }
    public void ShooterId4Trigger()
    {
        timerOn = true;
        PowerUp4CountDown();
    }
    public void ShooterId5Trigger()
    {
        timerOn = true;
        PowerUp5CountDown();
    }
    public void InvincibilityTrigger()
    {
        invincibilityTimerOn = true;
        InvincibilityItemCountDown();
    }

    public void PowerUp1CountDown()
    {
        iconPowerUp1.SetActive(true);
        iconPowerUp2.SetActive(false);
        iconPowerUp3.SetActive(false);
        iconPowerUp4.SetActive(false);
        iconPowerUp5.SetActive(false);

        if (timerOn == true)
        {
            powerUpCountDown = shooterType.powerUp1Time;
            powerUpTime = shooterType.powerUp1Time;
        }
    }
    public void PowerUp2CountDown()
    {
        iconPowerUp1.SetActive(false);
        iconPowerUp2.SetActive(true);
        iconPowerUp3.SetActive(false);
        iconPowerUp4.SetActive(false);
        iconPowerUp5.SetActive(false);

        if (timerOn == true)
        {
            powerUpCountDown = shooterType.powerUp2Time;
            powerUpTime = shooterType.powerUp2Time;
        }
    }
    public void PowerUp3CountDown()
    {
        iconPowerUp1.SetActive(false);
        iconPowerUp2.SetActive(false);
        iconPowerUp3.SetActive(true);
        iconPowerUp4.SetActive(false);
        iconPowerUp5.SetActive(false);

        if (timerOn == true)
        {
            powerUpCountDown = shooterType.powerUp3Time;
            powerUpTime = shooterType.powerUp3Time;
        }
    }
    public void PowerUp4CountDown()
    {
        iconPowerUp1.SetActive(false);
        iconPowerUp2.SetActive(false);
        iconPowerUp3.SetActive(false);
        iconPowerUp4.SetActive(true);
        iconPowerUp5.SetActive(false);

        if (timerOn == true)
        {
            powerUpCountDown = shooterType.powerUp4Time;
            powerUpTime = shooterType.powerUp4Time;
        }
    }
    public void PowerUp5CountDown()
    {
        iconPowerUp1.SetActive(false);
        iconPowerUp2.SetActive(false);
        iconPowerUp3.SetActive(false);
        iconPowerUp4.SetActive(false);
        iconPowerUp5.SetActive(true);

        if (timerOn == true)
        {
            powerUpCountDown = shooterType.powerUp5Time;
            powerUpTime = shooterType.powerUp5Time;
        }
    }

    public void InvincibilityItemCountDown()
    {
        if (invincibilityTimerOn == true)
        {
            invincibilityCountDown = player.invincibilityTime;
            invincibilityTime = player.invincibilityTime;
        }
    }

    void PowerUpCountDown()
    {
        if (timerOn == true)
        {
            powerUpCountDown -= Time.deltaTime;
            powerUpBarTime.fillAmount = powerUpCountDown / powerUpTime;

            if (powerUpCountDown < 0)
            {
                shooterType.shooterId = 0;
                shooterType.SwitchShooterId();
                timerOn = false;
            }
        }
    }

    void InvincibilityCountDown()
    {
        if (invincibilityTimerOn == true)
        {
            invincibilityCountDown -= Time.deltaTime;
            invincibilityBarTime.fillAmount = invincibilityCountDown / invincibilityTime;

            if (invincibilityCountDown < 0)
            {
                player.sprite.color = new Color(1, 1, 1, 1);
                player.isInvincible = false;
                invincibilityTimerOn = false;
            }
        }
    }
}
