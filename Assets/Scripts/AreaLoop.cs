using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLoop : MonoBehaviour
{
    private GameObject PlayerPos;
    public GameObject Ocean;
    void Start()
    {
        PlayerPos = GameObject.Find("Player");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        
        Ocean.transform.position=PlayerPos.transform.position ;
    }
}
