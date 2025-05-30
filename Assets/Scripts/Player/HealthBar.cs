using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    Player player;

    float initialHealth;

    void Start()
    {
        healthBar = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        initialHealth = player.health;
    }

    void Update()
    {
        healthBar.fillAmount = player.health / initialHealth;
    }
}
