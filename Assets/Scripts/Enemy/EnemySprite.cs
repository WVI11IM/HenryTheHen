using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySprite : MonoBehaviour
{
    public AIPath aiPath;
    [SerializeField] Enemy enemy;
    Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Morcego (Sprite)")
        {
            lastPos = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name != "Morcego (Sprite)")
        {
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (aiPath.desiredVelocity.x <= 0.01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else    //BAT ONLY
        {
            if (transform.position.x > lastPos.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (transform.position.x < lastPos.x)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            lastPos = transform.position;
        }
    }

    public void EnemyDeathSound()
    {
        enemy.EnemyDeathSound();
    }
    public void EnemyDestroy()
    {
        enemy.sprite.color = new Color(1f, 1f, 1f, 1f);
        enemy.EnemyDestroy();
    }

    public void ExpandCollider()
    {
        enemy.circlecollider2d.radius = 1.8f;
    }

    public void DisableCollider()
    {
        enemy.circlecollider2d.enabled = false;
    }

    public void SlimeExplosion()
    {
        enemy.slimeExplosion.SetActive(true);
    }
}
