using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    Transform enemyTransform;
    public float enemyHealth;
    public float enemyDmg;
    bool isAlive = true;
    
    public bool isFaster1 = false;
    public bool isFaster2 = false;

    public float normalSpd;
    public float faster1;
    public float faster2;

    public SpriteRenderer sprite;
    public Animator animator;
    public CircleCollider2D circlecollider2d;   //deixar vazio
    CapsuleCollider2D capsulecollider2d;

    public GameObject slimeExplosion;
    public GameObject corn;

    [Range(0, 100)]
    public float cornOdds;

    public string deathSound;

    void Start()
    {
        enemyTransform = GetComponent<Transform>();
        circlecollider2d = GetComponent<CircleCollider2D>();
        capsulecollider2d = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (!isFaster1 && !isFaster2)
        {
            if (gameObject.name != "Morcego(Clone)")
            {
                AIPath aipath = GetComponent<AIPath>();
                aipath.maxSpeed = normalSpd;
            }
            else    //BAT ONLY
            {
                BatFollow batFollow = GetComponent<BatFollow>();
                batFollow.batSpeed = normalSpd;
            }
        }
        
        else if (isFaster2)
        {
            if (gameObject.name != "Morcego(Clone)")
            {
                AIPath aipath = GetComponent<AIPath>();
                aipath.maxSpeed = faster2;
            }
            else    //BAT ONLY
            {
                BatFollow batFollow = GetComponent<BatFollow>();
                batFollow.batSpeed = faster2;
            }
        }
        else if (isFaster1)
        {
            if (gameObject.name != "Morcego(Clone)")
            {
                AIPath aipath = GetComponent<AIPath>();
                aipath.maxSpeed = faster1;
            }
            else    //BAT ONLY
            {
                BatFollow batFollow = GetComponent<BatFollow>();
                batFollow.batSpeed = faster1;
            }
        }
        
        if (enemyHealth <= 0.0)
        {
            isAlive = false;
        }

        if (isAlive == false)
        {
            if (gameObject.name != "Morcego(Clone)")
            {
                AIPath aipath = GetComponent<AIPath>();
                aipath.canMove = false;
                if (gameObject.name != "Cobra(Clone)" && gameObject.name != "Slime(Clone)") circlecollider2d.enabled = false;
                else if (gameObject.name == "Cobra(Clone)") capsulecollider2d.enabled = false;
                animator.SetBool("isAlive", false);
            }
            else    //BAT ONLY
            {
                BatFollow batFollow = GetComponent<BatFollow>();
                batFollow.enabled = false;
                circlecollider2d.enabled = false;
                animator.SetBool("isAlive", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damager"))
        {
            animator.SetTrigger("hit");
            AudioManager.Instance.PlaySFX2("enemyDamage", 0.1f, 0.25f);

            if(collision.name == "Egg4(Clone)")
            {
                AudioManager.Instance.PlaySFX2("egg4Impact", 0.3f, 0.5f);
            }

            Egg damage = collision.gameObject.GetComponent<Egg>();
            enemyHealth -= damage.eggDmg;
        }

        if (collision.CompareTag("Player") && gameObject.name == "Slime(Clone)")
        {
            animator.SetBool("isAlive", false);
        }
    }
    public IEnumerator Paralyze()
    {
        if (gameObject.name != "Morcego(Clone)")
        {
            AIPath aipath = GetComponent<AIPath>();
            aipath.canMove = false;
            animator.SetBool("isStopped", true);
            yield return new WaitForSeconds(4);
            aipath.canMove = true;
            animator.SetBool("isStopped", false);
        }
        else    //BAT ONLY
        {
            BatFollow batFollow = GetComponent<BatFollow>();
            float oldSpeed = batFollow.batSpeed;
            batFollow.batSpeed = 0;
            animator.SetBool("isStopped", true);
            yield return new WaitForSeconds(4);
            batFollow.batSpeed = oldSpeed;
            animator.SetBool("isStopped", false);
        }
    }

    public void EnemyDeathSound()
    {
        AudioManager.Instance.PlaySFX(deathSound, 0.3f);
    }

    public void EnemyDestroy()
    {
        SpawnCorn();
        EnemyNumbers.enemyTotal -= 1;
        EnemyDeathCount.enemyCount += 1;
        Destroy(gameObject, 0.0f);
    }

    public void ParalyzeCollision()
    {
        StartCoroutine(Paralyze());
    }

    public void SpawnCorn()
    {
        float index = Random.Range(0, 100);
        print(index);
        if (index <= cornOdds)
        {
            Instantiate(corn, enemyTransform.position, Quaternion.identity);
        }
    }
}
