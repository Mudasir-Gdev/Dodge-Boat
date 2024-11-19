using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    private MissilesSpawner missilesSpawner;
    void Start()
    {
       missilesSpawner = GetComponent<MissilesSpawner>();
    }
    void Update()
    {
        
    }
    public void GameOver() {

        Debug.Log("GameOver");
        missilesSpawner.spawn = false;

    } 
}
