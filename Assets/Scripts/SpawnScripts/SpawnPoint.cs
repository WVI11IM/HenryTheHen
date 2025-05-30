using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //public Transform spawnTransform;
    public bool isOccupied = false;
    // Start is called before the first frame update
    void Start()
    {
        isOccupied = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isOccupied = false;
        }
    }
}
