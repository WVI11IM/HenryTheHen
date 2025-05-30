using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickSpawnManager : MonoBehaviour
{
    //[SerializeField] Transform[] spawnPoints;
    [SerializeField] SpawnPoint[] spawnPosition;
    [SerializeField] GameObject chick;
    public int chickNumber;
    
    void Start()
    {
        //SpawnChicks();
        List<SpawnPoint> Pontos = new List<SpawnPoint>();

        for (int i = 0; i < spawnPosition.Length; i++)
        {
            Pontos.Add(spawnPosition[i]);
        }

        for (int n = 0; n < chickNumber; n++)
        {
            int index = Random.Range(0, Pontos.Count);
            Instantiate(chick, Pontos[index].transform.position, Quaternion.identity);
            Pontos.Remove(Pontos[index]);
        }
    }
}
