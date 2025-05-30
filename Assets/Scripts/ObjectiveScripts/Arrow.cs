using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public ShooterJoystick shooter;
    public Player player;
    public GameObject arrow1;
    public GameObject arrow2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shooter.canTouch == true)
        {
            arrow1.SetActive(true);
        }
        if (player.hasChick == true)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(true);
        }
        if (ChickCount.chickCount >= 1)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
        }
    }
}
