using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public GameObject GameOver;
    private MissilesSpawner missilesSpawner;
    
    
    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(Singleton);
        }
    }
   
    void Start()
    {
        missilesSpawner = GetComponent<MissilesSpawner>();
    }
   
    public void gameover() {

        Debug.Log("GameOver");
        GameOver.gameObject.SetActive(true);        
        missilesSpawner.spawn = false;
        //Time.timeScale = 0;
    }
    
    
            
    


}
