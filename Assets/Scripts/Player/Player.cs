using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //dados
    public int playerId;
    public float health;
    float maxHealth;
    public float weight;
    public bool isAlive = true;
    public bool isInvincible = false;
    public bool isHitInvincible = false;

    public GameObject gotHp;
    bool onMud = false;
    public float spikesDmg;
    public ParticleSystem mudEffect;

    public bool hasChick = false;
    public GameObject hasChickText;

    ShooterJoystick shooterType;
    PowerUpBar powerUpBar;

    Rigidbody2D rb;
    CircleCollider2D circlecollider2d;

    [Space]
    public SpriteRenderer sprite;
    public Animator animator;
    public GameObject skin0;
    public GameObject skin1;
    public GameObject skin2;
    public GameObject skin3;
    [Space]

    public float hitInvincibilityTime;
    public float invincibilityTime;

    [Space]
    public int cornValue;

    void Start()
    {
        shooterType = GameObject.Find("Shooter").GetComponent<ShooterJoystick>();
        powerUpBar = GameObject.Find("PowerUpBars").GetComponent<PowerUpBar>();
        circlecollider2d = GetComponent<CircleCollider2D>();
        circlecollider2d.enabled = true;
        rb = GetComponent<Rigidbody2D>();
        maxHealth = health;
        hasChickText.SetActive(false);

        if (PlayerPrefs.GetInt("skinEquipped") == 3)
        {
            sprite = skin3.GetComponent<SpriteRenderer>();
            animator = skin3.GetComponent<Animator>();
            skin0.SetActive(false);
            skin1.SetActive(false);
            skin2.SetActive(false);
            skin3.SetActive(true);
            print("skin3");
        }
        else if (PlayerPrefs.GetInt("skinEquipped") == 2)
        {
            sprite = skin2.GetComponent<SpriteRenderer>();
            animator = skin2.GetComponent<Animator>();
            skin0.SetActive(false);
            skin1.SetActive(false);
            skin2.SetActive(true);
            skin3.SetActive(false);
            print("skin2");
        }
        else if (PlayerPrefs.GetInt("skinEquipped") == 1)
        {
            sprite = skin1.GetComponent<SpriteRenderer>();
            animator = skin1.GetComponent<Animator>();
            skin0.SetActive(false);
            skin1.SetActive(true);
            skin2.SetActive(false);
            skin3.SetActive(false);
            print("skin1");
        }
        else if (PlayerPrefs.GetInt("skinEquipped") == 0)
        {
            skin0.SetActive(true);
            skin1.SetActive(false);
            skin2.SetActive(false);
            skin3.SetActive(false);
            print("skin0");
        }

        if (hasChickText == null) return;
    }

    void Update()
    {
        if (shooterType.isShooting == true)
        {
            animator.SetBool("isShooting", true);
        }
        else animator.SetBool("isShooting", false);
        
        if (health <= 0.0)
        {
            isAlive = false;
        }

        if (isAlive == false)
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            if (collision.gameObject.name == "PowerUp0" || collision.gameObject.name == "PowerUp0(Clone)")
            {
                shooterType.shooterId = 0;
                powerUpBar.ShooterId0Trigger();
            }

            if (collision.gameObject.name == "PowerUp1" || collision.gameObject.name == "PowerUp1(Clone)")
            {
                shooterType.shooterId = 1;
                powerUpBar.ShooterId1Trigger();
                AudioManager.Instance.PlaySFX("powerUp", 0.25f);
            }

            if (collision.gameObject.name == "PowerUp2" || collision.gameObject.name == "PowerUp2(Clone)")
            {
                shooterType.shooterId = 2;
                powerUpBar.ShooterId2Trigger();
                AudioManager.Instance.PlaySFX("powerUp", 0.25f);
            }

            if (collision.gameObject.name == "PowerUp3" || collision.gameObject.name == "PowerUp3(Clone)")
            {
                shooterType.shooterId = 3;
                powerUpBar.ShooterId3Trigger();
                AudioManager.Instance.PlaySFX("powerUp", 0.25f);
            }

            if (collision.gameObject.name == "PowerUp4" || collision.gameObject.name == "PowerUp4(Clone)")
            {
                shooterType.shooterId = 4;
                powerUpBar.ShooterId4Trigger();
                AudioManager.Instance.PlaySFX("powerUp", 0.25f);
            }

            if (collision.gameObject.name == "PowerUp5" || collision.gameObject.name == "PowerUp5(Clone)")
            {
                shooterType.shooterId = 5;
                powerUpBar.ShooterId5Trigger();
                AudioManager.Instance.PlaySFX("powerUp", 0.25f);
            }

            if (collision.gameObject.name == "HealthUp" || collision.gameObject.name == "HealthUp(Clone)")
            {
                HealthUp();
            }

            if (collision.gameObject.name == "Invincibility" || collision.gameObject.name == "Invincibility(Clone)")
            {
                Invincibility();
                powerUpBar.InvincibilityTrigger();
            }

            if (collision.gameObject.name == "Corn" || collision.gameObject.name == "Corn(Clone)")
            {
                Save.Instance.AddMoney(cornValue);
                AudioManager.Instance.PlaySFX("item", 0.5f);
            }

            shooterType.SwitchShooterId();
            Destroy(collision.gameObject);  //destroi o powerup pego
        }

        if (collision.gameObject.CompareTag("Enemy") && !isInvincible && !isHitInvincible)
        {
            if (collision.gameObject.name == "Slime(Clone)")
            {
                StartCoroutine(MudEffect());
            }
            
            Enemy damage = collision.gameObject.GetComponent<Enemy>();
            health -= damage.enemyDmg;
            AudioManager.Instance.PlaySFX("henryHit", 0.75f);
            if (isAlive && health > 0)
            {
                StartCoroutine(HitInvincibility());
            }
        }

        if (collision.gameObject.CompareTag("Mud") && !isInvincible && !isHitInvincible && !onMud)
        {
            StartCoroutine(MudEffect());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isInvincible && !isHitInvincible)
        {
            if (collision.gameObject.name == "Slime(Clone)")
            {
                StartCoroutine(MudEffect());
            }
            if (collision.gameObject.name == "Zumbi(Clone)")
            {
                Enemy damage = collision.gameObject.GetComponent<Enemy>();
                health -= damage.enemyDmg;
            }

            else if (collision.gameObject.name == "Raposo(Clone)")
            {
                Enemy damage = collision.gameObject.GetComponent<Enemy>();
                health -= damage.enemyDmg;
            }

            else
            {
                Enemy damage = collision.gameObject.GetComponent<Enemy>();
                health -= damage.enemyDmg;
            }

            AudioManager.Instance.PlaySFX("henryHit", 0.75f);
            if (isAlive && health > 0)
            {
                StartCoroutine(HitInvincibility());
            }
        }

        if (collision.gameObject.CompareTag("Mud") && !isInvincible && !isHitInvincible && !onMud)
        {
            StartCoroutine(MudEffect());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  //SPIKES
    {
        if (collision.gameObject.CompareTag("Spikes") && !isInvincible && !isHitInvincible)
        {
            health -= spikesDmg;
            AudioManager.Instance.PlaySFX("henryHit", 0.75f);
            AudioManager.Instance.PlaySFX("spikes", 1f);
            if (isAlive && health > 0)
            {
                StartCoroutine(HitInvincibility());
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)   //SPIKES
    {
        if (collision.gameObject.CompareTag("Spikes") && !isInvincible && !isHitInvincible)
        {
            health -= spikesDmg;
            AudioManager.Instance.PlaySFX("henryHit", 0.75f);
            AudioManager.Instance.PlaySFX("spikes", 1f);
            if (isAlive && health > 0)
            {
                StartCoroutine(HitInvincibility());
            }
        }
    }

    IEnumerator HitInvincibility()
    {
        isHitInvincible = true;
        animator.SetTrigger("hit");
        yield return new WaitForSeconds(hitInvincibilityTime / 10);
        for (int n = 0; n < 2; n++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(hitInvincibilityTime / 10);
            sprite.enabled = true;
            yield return new WaitForSeconds(hitInvincibilityTime / 10);
        }
        for (int n = 0; n < 4; n++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(hitInvincibilityTime / 20);
            sprite.enabled = true;
            yield return new WaitForSeconds(hitInvincibilityTime / 20);
        }
        isHitInvincible = false;
    }

    public void HealthUp()
    {
        health += (maxHealth/5) * 2;
        if (health > maxHealth) health = maxHealth;
        animator.SetTrigger("recover");
        gotHp.SetActive(true);
        AudioManager.Instance.PlaySFX("health", 0.75f);
    }
    public void Invincibility()
    {
        isInvincible = true;
        sprite.color = new Color(1, 1, 1, 0.5f);
        AudioManager.Instance.PlaySFX("invincibility", 0.75f);
    }

    IEnumerator MudEffect()
    {
        if (onMud == false)
        {
            onMud = true;
            rb.mass *= 2;
            mudEffect.Play();
            AudioManager.Instance.PlaySFX("mud2", 1f);
            yield return new WaitForSeconds(1.5f);
            AudioManager.Instance.PlaySFX("mud", 1f);
            yield return new WaitForSeconds(1.5f);
            mudEffect.Stop();
            rb.mass /= 2;
        }
        onMud = false;
    }

    public void Death()
    {
        circlecollider2d.enabled = false;
        shooterType.enabled = false;
        animator.SetBool("isAlive", false);
    }

    public void HasChickText()
    {
        hasChickText.SetActive(true);
    }
}