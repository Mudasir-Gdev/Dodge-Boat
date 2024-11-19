using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class MissilesSpawner : MonoBehaviour
{
    public Transform boatPos;
    //public GameObject Missile;
    private Vector3 offset;

    public GameObject[] Missiles;

    public bool spawn=true;
    private float spawnX;
    private float spawnZ;
    private float T ;
    void Start()
    {
        int t=Random.Range(7,10);
        if(spawn)
        InvokeRepeating("SpawnMissile", 2,t);
     
    }

    
    void Update()
    {
        
        T = Time.time;
    }

    int Index()
    {
        int FirstI , LastI ;

        Debug.Log(T);

        if (T > 56)
        {
            FirstI = 4;
            LastI = 6;
        }
        else if (T > 45)
        {
            FirstI = 3;
            LastI = 6;
        }
        else if (T > 35)
        {
            FirstI = 2;
            LastI = 5;
        }
        else if (T > 25)
        {
            FirstI = 1;
            LastI = 4;
        }
        else if (T > 15)
        {
            FirstI = 0;
            LastI = 3;
        }

        else
        {
            FirstI = 0;
            LastI = 1;
        }
        
        int i =Random.Range(FirstI, LastI);
        return i;
        Debug.LogWarning("Missile no " + i);
    }
    void SpawnMissile()
    {
        spawnX = Random.Range(-15, 15);
        spawnZ = Random.Range(15, 20);
        //Contains Spawn location
        Quaternion Spawndir = Quaternion.EulerRotation(Missiles[Index()].transform.rotation.x, Missiles[Index()].transform.rotation.y + 180f, Missiles[Index()].transform.rotation.z);
        offset = new Vector3(boatPos.position.x+spawnX,boatPos.position.y, boatPos.position.z +spawnZ);
        Instantiate(Missiles[Index()],offset,Spawndir);

        //Contains missiles List

        //Destroy the Missiles after timer

       
        
    }
}