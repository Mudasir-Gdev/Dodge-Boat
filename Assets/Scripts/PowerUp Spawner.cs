using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] PowerUps;
    public List<GameObject> Power = new List<GameObject>();

    private float offsetX;
    private float offsetY;
    private float SpawnX;
    private float SpawnY;
    void Start()
    {
        InvokeRepeating("powerUpSpawner", 4, 5);
    }
    
    private void powerUpSpawner()
    {
        //Location
        offsetX = Random.Range(15, 30);
        offsetY = Random.Range(35,60);
        int a = Random.Range(0, 1);
        if (a == 0)
        {
            SpawnX = -(offsetX);
            SpawnY = -(offsetY);
        }
        else
        {
            SpawnX = offsetX;
           SpawnY = offsetY;
        }
        Vector3 spawnPos = new Vector3 (player.position.x+SpawnX,player.position.y, player.position.z+SpawnY);
        //percentage for spawn power ups chances
        int randomValue= Random.Range(0,100);
        
        int index;
        switch (randomValue)
        {
            case int v when v > 60 && v < 75:
                index = 2;
                break;
            case int v when v > 75:
                index = 1;
                break;
            default:
                index = 0;
                break;
        }

        
        if (Power.Count < 7)
        {
            Power.Add(Instantiate(PowerUps[index], spawnPos, Quaternion.EulerAngles( 90f, 0, 0)));
        }
           


    }
}
