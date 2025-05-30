using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Egg : MonoBehaviour
{
    public Vector2 eggSpd;
    public float eggDmg;
    public float lifetime;
    Rigidbody2D eggRb;
    [SerializeField] ParticleSystem effect;
    [SerializeField] GameObject explosion;

    public string shootSound;

    void Awake()
    {
        eggRb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        eggRb.AddRelativeForce(eggSpd);
        AudioManager.Instance.PlaySFX2(shootSound, 0.15f, 0.4f);
    }

    void Update()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(effect, transform.position, transform.rotation);

        if (gameObject.name == "Egg0(Clone)" || gameObject.name == "Egg1(Clone)" || gameObject.name == "Egg2(Clone)" || gameObject.name == "Egg2.1" || gameObject.name == "Egg2.2" || gameObject.name == "Egg2.3")
        {
            AudioManager.Instance.PlaySFX2("egg012Impact", 0.1f, 0.2f);
        }

        if (gameObject.name == "Egg3(Clone)")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            AudioManager.Instance.PlaySFX2("egg3Impact", 0.4f, 0.6f);
        }

        if (gameObject.name != "Egg4(Clone)")
        {
            Destroy(gameObject);
        }

        if (gameObject.name == "Egg5(Clone)")
        {
            AudioManager.Instance.PlaySFX2("egg5Impact", 0.15f, 0.35f);
            Enemy aipath = collision.gameObject.GetComponent<Enemy>();
            aipath.ParalyzeCollision();
        }
    }
}
