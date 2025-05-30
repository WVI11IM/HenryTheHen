using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayIntro : MonoBehaviour
{
    [SerializeField] ShooterJoystick playerShooter;
    [SerializeField] GameObject objectiveText;

    void Start()
    {
        objectiveText.SetActive(false);
        playerShooter.canTouch = false;
    }

    public void DeactivateIntro()
    {
        playerShooter.canTouch = true;
        objectiveText.SetActive(true);
        gameObject.SetActive(false);
    }

    
}
