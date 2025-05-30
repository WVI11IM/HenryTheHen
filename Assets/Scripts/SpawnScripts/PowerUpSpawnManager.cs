using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnManager : MonoBehaviour
{
    //[SerializeField] Transform[] spawnPoints;
    [SerializeField] SpawnPoint[] spawnPosition;
    [SerializeField] GameObject[] powerUps;
    public Transform chicken;
    public float spawnCooldown;
    float cooldown;
    

    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown > spawnCooldown)
        {
            SpawnPowerUps();
            cooldown = 0;
        }
    }

    void SpawnPowerUps()
    {
        List<SpawnPoint> Pontos = new List<SpawnPoint>();

        for (int i = 0; i < spawnPosition.Length; i++)
        {
            if (Vector2.Distance(chicken.position, spawnPosition[i].transform.position) > 3.5f && spawnPosition[i].isOccupied == false)
            {
                Pontos.Add(spawnPosition[i]);
            }
        }

        int index = Random.Range(0, Pontos.Count);
        int index2 = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[index2], Pontos[index].transform.position, Quaternion.identity);
        Pontos[index].isOccupied = true;

        Pontos.Clear();
    }

    //void SpawnPowerUps()
    //{
    //    List<Transform> Pontos = new List<Transform>();
    //
    //    for (int i = 0; i < spawnPoints.Length; i++)
    //    {
    //        if (Vector2.Distance(chicken.position, spawnPoints[i].position) > 3 && spawnPoint[i].isOccupied == false)
    //        {
    //            spawnPoint[i].isOccupied = true;
    //            Pontos.Add(spawnPoints[i]);
    //        }
    //    }
    //
    //    int index = Random.Range(0, Pontos.Count);
    //    int index2 = Random.Range(0, powerUps.Length);
    //    Instantiate(powerUps[index2], Pontos[index].position, Quaternion.identity);
    //}
}
